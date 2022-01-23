# desafioApCoders

*Instruções de como rodar a aplicação:
baixar o Dotnet 5.0, segue o link para praticidade: https://dotnet.microsoft.com/en-us/download/dotnet/5.0

baixar o PostgreSql

 -Criar um banco local.
 
 -Abrir o query tool e copiar e colar o conteudo do dbScript.txt, e executar o comando.

Entrar na pasta raiz da aplicação e rodar o cmd.

 -Compilar a aplicação usando o comando: dotnet run ConnectionString="User ID=postgres;Password=123;Host=localhost;Port=5432;Database=postgres;"
 Lembrando de usar a sua propria connection string no lugar do "User ID=postgres;Password=123;Host=localhost;Port=5432;Database=postgres;"
 Copiar o link do localhost que ira aparecer e colar em uma pagina da web.
 Entrar na pagina como "não seguro" se necessario.

*Tecnologias utilizadas:

 -Visual studio community 19.
 
 -PostgreSql.
 
 *A solução foi criada usando três projetos
 
  -Core() onde é implementado a logica.
  
  -desafioApCoders() onde é implementado a parte que sera exibida na tela.
  
  -Repositorio() onde é implementado toda parte de banco de dados.
  
  
*Essa aplicação foi feita com o padrão Mvc.

*Diagrama do banco de dados.png mostra a modelagem do banco de dados.

*A documentação da Api foi feita usando Swagger, segue o link: https://localhost:44376/swagger/index.html
