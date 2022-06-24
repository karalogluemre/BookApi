using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Persistence.Migrations
{
    public partial class StoredProcedureCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure [dbo].[BookSelectProcedure]
                                    @typeId uniqueidentifier = null,
			                       	@subTypeId uniqueidentifier = null,
			                       	@authorId uniqueidentifier = null,
			                       	@search nvarchar(100) = null
                                   AS
                                   BEGIN
                                      SET NOCOUNT ON;

                                      select 
									  b.Name [Name] ,
									  b.PageCount [PageCount],
									  t.Name TypeName,
									  st.Name SubTypeName,
									  a.Name AuthorName
									  from BookContext.Book b
			                          inner join BookContext.Author a on b.AuthorId = a.Id
			                          inner join BookContext.SubType st on b.SubTypeId = st.Id
			                          inner join BookContext.Type t on t.Id = st.TypeId

			                          where (@search is null or b.[Name] like N'%'+@search+'%')
			                          and (@typeId is null or st.TypeId = @typeId)
			                          and (@subTypeId is null or b.SubTypeId = @subTypeId)
			                          and (@authorId is null or b.AuthorId = @authorId)
                                   END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC UpdateProfilesCountry");
        }
    }
}
