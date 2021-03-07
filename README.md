# Gestão de Ouvidoria
TESTE DE APTIDÃO PARA ANALISTA DE SISTEMAS C#
## Tecnologias Utilizadas
* ASP.NET Core 3.1
* SQL Server
* Visual Studio 2019
* IIS Express
## Instalação 
1. Abra o arquivo: ***appsettings.json*** que pode ser localizado a partir da raiz do projeto no caminho: *Ouvidoria/Ouvidoria/appsettings.json*;
2. Em seguida preencha as informações de "Email" e "Senha" com as de uma conta do Gmail;
3. Importante ressaltar que será necessário permitir que seu E-mail seja acessado por aplicações menos seguras, para isso será necessário fazer login e entrar neste link (como demonstrado na imagem 2): https://myaccount.google.com/u/0/lesssecureapps?pageId=none&pli=1&rapt=AEjHL4O5dBuUtrl6ZAHax_EcfTn4ld0wKi5gZHKmVGAv0zMgS6kAJ22mkcR18D1YHsskCL8rmSSMVrzLBx9RJNyVrftPj74uPw
![ConnectionString](https://i.imgur.com/ga6iR1z.png)\
(**Imagem 1**: appsettings.json, em vermelho a string de conexão e em preto as informações de e-mail.)
![PermissaoGoogle](https://i.imgur.com/7butCFz.png)\
(**Imagem 2**: Foto da página de Permissão do Google.)
4. Configurações feitas abra o projeto utilizando o Visual Studio e em seguida abra o **Console Gerenciador de Pacotes** e execute o comando:
```bat
Update-Database
```
5. Ao fim da construção do banco você estará livre para executar o projeto.
## Documentos
### Diagrama de Classes - Modelos
![ClassesModelo](https://i.imgur.com/QDH94cy.png)\
(**Imagem 3**: Diagrama de classes focado na estrutura dos modelos.)
### Diagrama de Classes - Controladores
![ClassesModelo](https://i.imgur.com/dsphV2o.png)\
(**Imagem 4**: Diagrama de classes focado na estrutura dos controladores.)
## Contato
### Guilherme Luiz Simões Rigon
E-mail: [guilherme.rigon1988@gmail.com](mailto:guilherme.rigon1988@gmail.com)\
Linkedin: [Guilherme Rigon](https://www.linkedin.com/in/guisimoesr/)
