Para criar as tabelas no Entity Framework:
Abra o menu View/SQL Server Object Explorer
Expanda SQL Server
	Expanda (localdb)
	Expanda Databases
	Click da direita em Databases / Add New Database
		Click da direita no db criado / Refresh
			Click da direita no db criado / Properties
				Na janela properties, procure por Connection string
				Copie
					Em solution explorer, pasta 1 - Presentation Layer, procure pelo arquivo appsettings.json
						Substitua a string em vermelho ao lado de "Conexao"
							Click novamente em Solution Explorer e procure na pasta 4 - Infrastructure o arquivo appsettings.json
								Substitua a string em vermelho ao lado de "Conexao"

Procure o projeto File.Infra.Repository / Click da direita / Set as startup project

Click no menu Tools / Nuget Package Manager / Package Manager Console, abrirá uma janela na parte inferior do Visual Studio
	Ao lado de "Defaul Project", escolha File.Infra.Repository
	No cursor, digite Add-Migration nome_qualquer (enter)
	Digite Update-Database (enter)

Volte novamente ao Solution Explorer e procure por File.Presentation / Click da direita / Set as startup project e rode o projeto