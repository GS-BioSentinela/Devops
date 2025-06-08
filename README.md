# 🌿 BioSentinela – Monitoramento Inteligente de Áreas com Espécies em Extinção

Sistema completo desenvolvido com .NET e ASP.NET Core, voltado para o monitoramento de áreas ambientais sensíveis utilizando sensores IoT. O BioSentinela permite o registro automático de alertas ambientais, conta com autenticação básica integrada, documentação interativa com Swagger.

---

## 📌 Objetivo do Projeto

O BioSentinela tem como missão auxiliar na preservação ambiental, monitorando regiões com fauna em risco de extinção. Através de sensores instalados em campo, o sistema identifica condições críticas (como fumaça, temperatura elevada ou baixa umidade) e emite alertas em tempo real.

---

## 👥 Equipe

- Gabriel Gomes Mancera RM:555427

- Victor Hugo Carvalho Pereira RM:558550

- Juliana de Andrade Sousa RM:558834

---

## 🛠 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Swagger / OpenAPI
- AutoMapper
- DTOs para entrada e saída
- Validações com DataAnnotations
- Arquitetura em camadas (Domain, Application, Infrastructure)
- Git e GitHub para versionamento

---

## ▶️ Instruções para Executar

### Pré-requisitos:
- .NET 8 SDK instalado
- Banco de dados Oracle disponível
- IDE como Visual Studio ou VS Code

### Passos:

1. Clone o repositório:
   ```bash
   git clone https://github.com/GS-BioSentinela/BioSentinela---.NET.git
    ```

2. Configure a string de coexão no arquivo appsettings.json:
  ```json
    "ConnectionStrings": {
    "DefaultConnection": "User Id=USUARIO;Password=SENHA;Data Source=localhost:1521/XEPDB1"
    }
  ```

3. Execute as migrations e atualize o banco:
  ```bash
    Update-Databese
  ```

4. Rode o projeto:
  ```bash
  dotnet run
  ```
5. Acesse a documentação da API:
  - Swagger UI: http://localhost:5264/swagger

---

## 🔗 Rotas Disponíveis

### 🛵 Regiaos (`/api/Regiaos`)

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | `/api/Regiaos`                | Lista todas as Regiões                   |
| GET    | `/api/Regiaos{id}`            | Busca Região por ID                      |
| POST   | `/api/Regiaos`                | Cadastra uma nova Região                 |
| PUT    | `/api/Regiaos{id}`            | Atualiza uma Região existente            |
| DELETE | `/api/Regiaos{id}`            | Remove uma Região                        |

### 🛵 Sensors (`/api/Sensors`)

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | `/api/Sensors`                | Lista todos os Sensor                    |
| GET    | `/api/Sensors{id}`            | Busca Sensor por ID                      |
| POST   | `/api/Sensors`                | Cadastra um novo Sensor                  |
| PUT    | `/api/Sensors{id}`            | Atualiza um Sensor existente             |
| DELETE | `/api/Sensors{id}`            | Remove um Sensor                         |

### 🛵 Alertas (`/api/Alertas`)

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | `/api/Alertas`                | Lista todos os Alertas                   |
| GET    | `/api/Alertas{id}`            | Busca Alerta por ID                      |
| POST   | `/api/Alertas`                | Cadastra um novo Alerta                  |
| PUT    | `/api/Alertas{id}`            | Atualiza um Alerta existente             |
| DELETE | `/api/Alertas{id}`            | Remove um Alerta                         |


### 🛵 Usuarios (`/api/Usuarios`)

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | `/api/Usuarios`               | Lista todos os Usuarios                  |
| GET    | `/api/Usuarios{id}`           | Busca Usuario por ID                     |
| POST   | `/api/Usuarios`               | Cadastra um novo Usuario                 |
| PUT    | `/api/Usuarios{id}`           | Atualiza um Usuario existente            |
| DELETE | `/api/Usuarios{id}`           | Remove um Usuario                        |


---
### 🔐 Autenticação

1. **Registre um novo usuário:**
    `POST /api/Usuarios`
    ```json
    {
      "username": "admin",
      "password": "123456"
    }

### 🌎 Regiões

5.  Criar região com:
    `POST /api/Regiaos`
    ```json
    {
      "nome": "Pantanal Sul",
      "bioma": "Pantanal"
    }
    ```
6.  Listar (`GET /api/Regiaos`)
7.  Buscar por ID (`GET /api/Regiaos/{id}`)
8.  Atualizar (`PUT /api/Regiaos/{id}`):
    ```json
    {
      "nome": "Pantanal Norte",
      "bioma": "Pantanal"
    }
    ```
9.  Deletar (`DELETE /api/Regiaos/{id}`)


### 🌡️ Sensores

10. Criar sensor com:
    `POST /api/Sensors`
    ```json
    {
      "tipo": "Temperatura",
      "localizacao": "-3.123, -60.456",
      "regiaoId": ""
    }
    ```
11. Listar (`GET /api/Sensors`)
12. Buscar por ID (`GET /api/Sensors/{id}`)
13. Atualizar (`PUT /api/Sensors/{id}`)  
    ```json
    {
      "tipo": "Umidade",
      "localizacao": "-3.124, -60.559",
      "regiaoId": ""
    }
    ```
14. Deletar (`DELETE /api/Sensors/{id}`)

### 🚨 Alertas

15. Criar Alertas:
    `POST /api/Alertas`
    ```json
    {
      "tipo": "Fumaça",
      "mensagem": "Fumaça detectada na floresta.",
      "sensorId": ""
    }
    ```
16. Listar (`GET /api/Alertas`)
17. Buscar por ID (`GET /api/Alertas/{id}`)
18. Atualizar (`PUT /api/Alertas/{id}`)  
    ```json
    {
      "tipo": "Incendio",
      "mensagem": "Fogo intenso na floresta.",
      "sensorId": ""
    }
    ```
19. Deletar (`DELETE /api/Alertas/{id}`)

### ⚠️ Validações e Erros

18. Tente criar um alerta com campo obrigatório vazio (ex: `tipo`) → Deve retornar erro 400.
19. Tente buscar um ID inexistente (ex: `GET /api/Alertas/999`) → Deve retornar erro 404 com mensagem customizada.














































