using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEzconet.Persistence.Migrations
{
    public partial class populaDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            //mb.Sql("INSERT INTO Sexos (Descricao) VALUES ('Masculino')");
            //mb.Sql("INSERT INTO Sexos (Descricao) VALUES ('Feminino')");
            mb.Sql("INSERT INTO Usuarios (Nome, DataNascimento, Email, Senha, SexoId)" +
                "VALUES ('Maria','11/23/1980','maria@teste.com','123456',2 )");
            mb.Sql("INSERT INTO Usuarios (Nome, DataNascimento, Email, Senha, SexoId)" +
                "VALUES ('Joao','10/15/1985','joao@teste.com','123456',1 )");
        }

        protected override void Down(MigrationBuilder mb)
        {
            //mb.Sql("DELETE FROM Sexos");
            mb.Sql("DELETE FROM Usuarios");
        }
    }
}
