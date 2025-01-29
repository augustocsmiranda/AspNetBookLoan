# AspNetBookLoan

AspNetBookLoan é uma aplicação web construída com ASP.NET Core para gerenciar empréstimos de livros. Este projeto oferece funcionalidades como listagem, cadastro, edição e exclusão de registros de empréstimos. 

## Funcionalidades

- **Listar Empréstimos:** Exibe todos os empréstimos cadastrados no sistema.
- **Cadastrar Empréstimo:** Permite adicionar um novo empréstimo com informações do recebedor, fornecedor e livro.
- **Editar Empréstimo:** Possibilita a edição de informações de um empréstimo existente.
- **Excluir Empréstimo:** Remove um registro de empréstimo do sistema.

## Estrutura do Projeto

### Controladores

#### `HomeController`
Controlador responsável pelas páginas iniciais e genéricas da aplicação.
- **Métodos:**
  - `Index()`: Exibe a página inicial.
  - `Privacy()`: Exibe a página de política de privacidade.
  - `Error()`: Gera uma página de erro com detalhes do problema.

#### `EmprestimoController`
Controlador responsável pelo gerenciamento dos empréstimos.
- **Métodos:**
  - `Index()`: Lista todos os empréstimos.
  - `Cadastrar()`: Renderiza a página de cadastro e salva novos empréstimos.
  - `Editar(int? id)`: Renderiza a página de edição e salva alterações em um empréstimo existente.
  - `Excluir(int? id)`: Renderiza a página de confirmação e remove um empréstimo.

### Modelos

- `EmprestimosModel`: Representa os dados de um empréstimo, incluindo ID, recebedor, fornecedor, livro e data da última atualização.

### Banco de Dados

O projeto utiliza o Entity Framework Core para gerenciar as operações de banco de dados. A tabela principal é `Emprestimos`, que contém os seguintes campos:

- **Id:** Identificador único do empréstimo.
- **Recebedor:** Nome de quem recebeu o livro.
- **Fornecedor:** Nome de quem forneceu o livro.
- **LivroEmprestado:** Título do livro emprestado.
- **dataUltimaAtualizacao:** Data da última atualização do registro.

### Dependências

- **ASP.NET Core MVC**: Framework utilizado para desenvolvimento da aplicação.
- **Entity Framework Core**: ORM usado para comunicação com o banco de dados.
- **Bootstrap**: Framework CSS para estilização e layout responsivo.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/augustocsmiranda/AspNetBookLoan.git

   
