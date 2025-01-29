using AspNetBookLoan.Data;
using AspNetBookLoan.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace AspNetBookLoan.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null || id == 0) {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                emprestimos.dataUltimaAtualizacao = DateTime.Now; 

                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro Realizado com Sucesso";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                
                var emprestimoDB = _db.Emprestimos.Find(emprestimo.Id);

                emprestimoDB.Fornecedor = emprestimo.Fornecedor;
                emprestimoDB.Recebedor = emprestimo.Recebedor;
                emprestimoDB.LivroEmprestado = emprestimo.LivroEmprestado;


                _db.Emprestimos.Update(emprestimoDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso";

                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id) 
        {
            if (id == null || id == 0) {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null) {
                return NotFound();
            }
            
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }
            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção Realizado com Sucesso";

            return RedirectToAction("Index");
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workBook = new XLWorkbook())
            {
                workBook.AddWorksheet(dados, "Dados Empréstimos");

                using (MemoryStream ms = new MemoryStream())
                {
                    workBook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Empréstimo.xls");
                }
            }
        }

        private DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados Empréstimos";

            dataTable.Columns.Add("Recebedor", typeof(string));
            dataTable.Columns.Add("Fornecedor", typeof(string));
            dataTable.Columns.Add("Livro", typeof(string));
            dataTable.Columns.Add("Data Emprestimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();

            if (dados.Count > 0) {
                dados.ForEach(emprestimo =>
                {
                    dataTable.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivroEmprestado, emprestimo.dataUltimaAtualizacao);
                });
            }

            return dataTable;
        }
    }
}
