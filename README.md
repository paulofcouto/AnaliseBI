# AnaliseBI

Para iniciar o projeto, inicialmente crie uma conexão com MySQL Workbench utilizando os seguintes paramêtros:

- server: localhost
- port: 4040
- user: root
- password: 123456
  
![image](https://github.com/paulofcouto/AnaliseBI/assets/22281160/bb33700d-24fb-4ade-9518-340f7b988427)

Agora será necessário criar o banco de dados e para isso você pode utilizar duas formas:

**Solução 1**

Rode o script abaixo para criar diretamente no banco de dados:

```sql
CREATE DATABASE IF NOT EXISTS stage;
USE stage;

CREATE TABLE IF NOT EXISTS stage.MultiStore (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    OrderID VARCHAR(255),
    OrderDate DATETIME,
    ShipDate DATETIME,
    ShipMode VARCHAR(255),
    CustomerID VARCHAR(255),
    CustomerName VARCHAR(255),
    CustomerAge INT,
    CustomerBirthday DATE,
    CustomerState VARCHAR(255),
    Segment VARCHAR(255),
    Country VARCHAR(255),
    City VARCHAR(255),
    State VARCHAR(255),
    RegionalManagerID VARCHAR(255),
    RegionalManager VARCHAR(255),
    PostalCode VARCHAR(255),
    Region VARCHAR(255),
    ProductID VARCHAR(255),
    Category VARCHAR(255),
    SubCategory VARCHAR(255),
    ProductName VARCHAR(255),
    Sales DECIMAL(18, 2),
    Quantity INT,
    Discount DECIMAL(18, 2),
    Profit DECIMAL(18, 2)
);
```

**Solução 2**

Abra o projeto no visual studio, clique em 'Tools' > 'NuGet Package Manager' > 'Package Manager Console'.
No console que se abriu, digite o comando 'Update-Database', os arquivos de configuração, irão criar todas as configurações necessárias para iniciar o projeto.
