using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEzconet.Persistence.Migrations
{
    public partial class populaDb2 : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Usuarios (Nome, DataNascimento, Email, Senha, Ativo, SexoId)" +
                "VALUES ('Maria','11/23/1980','maria@teste.com','123456', 0, 2 )");
            mb.Sql("INSERT INTO Usuarios (Nome, DataNascimento, Email, Senha, Ativo, SexoId)" +
                "VALUES ('Joao','10/15/1985','joao@teste.com','123456', 1, 1 )");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Usuarios");
        }
    }
}
