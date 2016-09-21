##Programando em Windows para o Linux com C# usando o Mono
####Guilherme Bencke, 
####Porto Alegre, 21 de Setembro de 2016

####Oque é o Mono?
O mono é uma implementação do .NET que permite que possamos programar em qualquer linguagem .NET (C#/F#/VB.NET) e rodar o mesmo codigo compilado tanto no linux quando windows..

####Oque precisamos?
* No Windows: Instalar o mono, baixando de 
http://www.mono-project.com/download/#download-win

* No Linux: Instalar o mono via apt-get digitando:

    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EFecho "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.listsudo apt-get update
    sudo apt-get install mono-complete mono-devel monodevelop

####Como programar em Windows
**Xamarim Studio**: Para programar em windows é necessário instalar o Xamarin Studio que pode ser baixado de:
http://www.monodevelop.com/download/

###Depurando em Windows
Para depurar em windows é apenas necessário ter o mono instalado e o programa rodando no xamarin studio, é o mesmo processo que usamos normalmente no visual studio.

###Como Rodar no Linux
Para rodar no linux é apenas necessário copiar os arquivos e chamar o executável normalmente COMO FARIAMOS NO WINDOWS

###Desenvolvimento em Linux
Para desenvolver em linux, utilizamos o MonoDevelop que é muito parecido com o Xamarin Studio e é o mesmo processo do windows, na realidade o MonoDevelop é uma versão free do Xamarin Studio.

###Dicas para Desenvolvimento MultiPlataforma
* **Detectando a Plataforma**: Alguns codigos são dependente de sistema operacional, para saber aonde estamos, devemos usar o objeto Environment.OSVersion
* **NuGet**: Sempre que possivel baixar os componentes usando NuGet para que sejam componentes realmente certificados pela Microsoft
* **Componentes 100% .NET**: Somente são multi-plataforma os componentes que realmente sejam 100% .NET, componentes com elementos nativos podem nao funcionar pois tem partes desenvolvidos em codigo C++ que pode não ser entendido por multi sistemas

###Exemplo: Job Acessando Postgres

    Executar exemplo na pasta samples

###Exemplo: Robo com Selenium

    Executar exemplo na pasta samples

###Mas, e Aplicações Desktop (Windows Forms)?
O Mono usa o GTK# que é baseado no GNOME como plataforma de desenvolvimento Desktop, funciona tanto no Windows quanto linux, mas, é bastante diferente do Windows Forms, por isso é conteudo para outra apresentação. 

###Mas, e Aplicações Web (ASP.NET)?
Anunciado em Janeiro de 2016, o ASP.NET Core é a plataforma microsoft multi-plataforma e é o modo sugerido para aplicações web, essas aplicações podem ser desenvolvidas com o Visual Studio Code ou o próprio Visual Studio e usam uma implementação do .NET chamado .NET Core que não tem nada a haver com o mono.

**O .NET Core irá substituir o mono num futuro próximo**

###Conclusão 
O mono é uma forma muito fantástica de se trabalhar com codigo em linux e windows ao mesmo tempo, existem atualmente muitas iniciativas da microsoft em portar o .NET para o Linux e Mac OS, mas, o mono sendo um projeto com mais de 10 anos de existencia é de longe a opção mais estável no momento.

