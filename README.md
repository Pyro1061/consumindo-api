# 📌 Projeto de API - Consumindo API

## 🧾 Sobre o projeto

Este projeto é uma **API simples feita em ASP.NET Core** para gerenciar alunos.

Ela permite:

* 📄 **Listar alunos cadastrados**
* ➕ **Adicionar novos alunos**

Os dados ficam armazenados **temporariamente em memória**, ou seja, **não existe banco de dados**. Quando a aplicação é reiniciada, os dados são perdidos.

---

# ⚙️ Como a API funciona

### 1️⃣ Listar alunos

A rota abaixo retorna todos os alunos cadastrados.

```
GET /aluno
```

Ela retorna uma lista em formato **JSON** com os alunos armazenados.

---

### 2️⃣ Adicionar um aluno

A rota abaixo permite cadastrar um novo aluno.

```
POST /aluno
```

Para adicionar um aluno é necessário enviar o nome e a idade do aluno.

A API verifica se os dados são válidos e então **gera automaticamente uma matrícula** para o aluno.

---

# 🧠 Armazenamento de dados

Os alunos são guardados em uma **lista dentro da própria aplicação**, ou seja:
* os dados existem **apenas enquanto a API estiver rodando**
* ao reiniciar a aplicação, **os dados são apagados**

Esse tipo de armazenamento é usado apenas para **testes e aprendizado**.

---

# 🌐 Conecção com um site

Dentro da pasta chamada **MeuSite**, contém um site simples que pode **consumir a API** para mostrar ou cadastrar alunos, tenha certeza que a API esteja rodando para testar o site.
