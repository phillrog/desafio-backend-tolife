# Desafio ToLife

# 📱 Catálogo de Ofertas de Aparelhos e Planos

Este projeto consiste em uma plataforma para exibição de ofertas de aparelhos celulares vinculados a planos de telefonia.

## 🛠️ Tecnologias Utilizadas

### **Backend (API)**
* **.NET 8 / ASP.NET Core Web API / Entity Framework Core / Migrations / AutoMapper**
* **DDD (Domain-Driven Design)**: Implementação de Entidades e **Value Objects** (Objetos de Valor).
* **Clean Architecture**: Separação de responsabilidades em camadas (Domain, Application, Infrastructure).
* **SQL Server**: Banco de dados relacional utilizando MSSQLLocalDB.
* **Swagger (OpenAPI)**: Documentação interativa com comentários XML integrados.

### **Frontend (Angular)**
* **Angular 21**
* **NgModules / Lazy Loading / TypeScript / Bootstrap 5 / RxJS**

---

## 🏗️ Arquitetura e Padrões

### **Backend**
O projeto segue os princípios da **Clean Architecture**, onde o domínio é o coração da aplicação, isolado de dependências externas:
* **Domain:** Contém as entidades `Aparelho` e `Plano`, os Value Objects `Localidade` e `Schedule`, enum tipo de plano e as interfaces de repositórios.
* **Application:** Serviço para buscar as ofertas, MappingProfile das entidades e DTOs de entrada/saída.
* **Infrastructure:** Implementação dos Repositórios, mapeamento das entidades com Fluent API, Migrations, Seed e contexto do banco de dados.

### **Frontend**
No Angular criado o módulo completo da página de ofertas (componente, route, modulo, models, service) e config de rota utilizando Lazy Loading no app-route.

---

## 📝 Regras Implementadas

A listagem de ofertas dos planos segue regra via LINQ:
1.  **Vigência**: Apenas planos com data de início superior à data atual são exibidos.
2.  **Unicidade**: Um plano (identificado por Nome/Tipo) só pode aparecer uma vez por oferta.
3.  **Prioridade**: Em caso de múltiplas localidades, o sistema seleciona automaticamente o plano de maior prioridade (onde `1` é o nível máximo).
4.  **Todos os dados dos planos**: todos os dados dos planos são exibido e formatados.

---

## 🚀 Como Executar

### **Passos**
1.  Clone o repositório.
2.  No diretório do src: 
    * `dotnet ef database update --project DesafioToLife.Infrastructure --startup-project DesafioToLife.API`
3.  No diretório do DesafioToLife.Web:
    * `npm install`
    * `ng serve`
4.  Acesse `http://localhost:4200`

# Resultado
Frontend

<img width="1872" height="957" alt="image" src="https://github.com/user-attachments/assets/fb4118d1-72cb-4a6d-845f-b0e4afd3dbd5" />

Backend

<img width="1880" height="958" alt="image" src="https://github.com/user-attachments/assets/10d693bc-f68d-40e4-9326-048042b0a6dd" />

Banco

<img width="466" height="541" alt="image" src="https://github.com/user-attachments/assets/d3f319bd-5ebf-4efc-b6a0-65b1c2c61501" />


