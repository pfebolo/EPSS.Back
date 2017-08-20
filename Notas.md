# Notas

## Net Core
* Para ir actualizando: __https://www.microsoft.com/net/download/core#/current/sdk__
  - Se migró a version: 1.1.0-preview1-005077
    - Se ejecutó comando: dotnet migrate --report-file migrate.txt 



* Verificar que en UBUNTU seguramente se actualiza automaticamente
  - Si es así, entonces mantener sincronizados las computadoreas NB1 y SUPERVISOR

### Orden de llamada de Ejecución, al inicio del programa
1. Main
    1. new WebHostBuilder().UseStartup<tipo> //en esta instrucción se indica el  el type (nombre de la clase) usada para el la inicialización del WebHost (en gral la clase se llama 'StartUp')
        1. Startup (constructor)
        2. StartUp.ConfigureServices
        3. StartUp.Configure
    2. Otras instruciones
    3.host.Run()  //Ejecuta en loop infinito el sitio web  
2. End



## Base de datos

### Scaffoldear
#### Comando usado para generar codigo de modelo de base de datos inicial
  * dotnet ef dbContext scaffold "Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;" Microsoft.EntityFrameworkCore.SqlServer -a -c escuelapsdelsurContext -t Paises -t Provincias -t Partidos -t CodigosPostales -t Localidades -t modalidades -t alumnos -t Legajos -o Models -f

#### Tareas para ir actualizando el acceso a DB
* Verificar que la carpeta donde se ejecuta el _scaffold_ se llame **EPSS** (es necesario ya que de este nombre genera el namespace base)
* Si existe la carpeta **Models**, renombrarla
* 'scaffoldear' con las tablas nuevas
* Comparar carpeta vieja con la nueva
  * Mergear la carpeta nueva con la vieja
  * Verificar el archivo de contexto, y ajustar de ser necesario
* __*Comando*__:  
dotnet ef dbContext scaffold "Data Source=192.168.1.41;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;User Id=sa;Password=sasasasa;" Microsoft.EntityFrameworkCore.SqlServer -a -c escuelapsdelsurContext -t Paises -t Provincias -t Partidos -t CodigosPostales -t Localidades -t lugares -t eventos -t modalidades -t Carreras -t MediosDeContacto -t interesados -t interesados_eventos -t alumnos -t Legajos -t NivelesEstudios -t Estudios -t Modos -t Turnos -t Promociones -t EstadosCurso -t Cursos -t Coordinadores -t Grupos -t Coordinacion -t Trabajos -o Models -f
* Borrar carpeta nueva
* Renombrar nuevamente la carpeta donde se ejcutó el *scaffold* a su nombre original


### Como conectar desde Linux (en realidad desde otra computadora) al Sql Server
* 1ro) Habilitar al SQLServer a recibir conexiones remotas
* 2do) Habilitar al SQLServer a recibir conexiones via TCP-IP y configurarle el port 1433
    Your SQL Server is installed as named instance, so first of all try connecting to your server using the following server name: IP Address\SQLEXPRESS.  
    When you install SQL Server as named instance it uses dynamic TCP/IP ports by default, so it is not possible to connect to it whitout specifying instance name (just IP address). If you need to connect to your server without using instance name you have to reconfigure your server to use static TCP port. To do it please perform the following:
    - open SQL Server Configuration Manager;
    - switch to the SQL Server Network Configuration | Protocols for SQLEXPRESS;
    - double-click the TCP/IP protocol;
    - select the Yes value in the Enabled field;
    - switch to the IP Addresses tab;
    - find the IPAll section;
    - clear the TCP Dynamic Ports field in that section;
    - specify the 1433 value in the TCP Port field:

    En la cadena de conexion solo usar la direccion IP, sin especificar la instancia.
   
* 3ro) Habilitar el port 1433 en Firewall

* __ref:__       
https://blogs.msdn.microsoft.com/walzenbach/2010/04/14/how-to-enable-remote-connections-in-sql-server-2008/
http://www.solvetic.com/tutoriales/article/2657-como-abrir-o-cerrar-un-puerto-con-el-firewall-en-windows-10/
http://dba.stackexchange.com/questions/62165/i-cant-connect-to-my-servers-sql-database-via-an-ip-address

* __Otros:__  
    * Cadenas de conexiones usadas  
        Local NB01
        @"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;"
        Desde Linux hacia NB01
        @"Data Source=192.168.1.41;Connect Timeout=15;Encrypt=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;User Id=sa;Password=sasasasa;";
    *  Como Monitirear si el sqlserver abre el port y está habilitado  
        - Abrir el Monitor de recursos
        - Solapa: Red
        - Seccion: Puertos de escucha
            - Buscar proceso: sqlservr.exe 
            - Debe verse:
                - Proceso: sqlservr.exe
                - PID: [indistinto]
                - Direccion: IPv4 sin especificar
                - Port: 1433
                - Protocolo: TCP
                - Estado de Firewall: Permitido, no restringido






