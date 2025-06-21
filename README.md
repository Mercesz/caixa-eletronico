# 💸 Caixa Eletrônico em C#

Esse é um projeto simples de console que simula um **caixa eletrônico**. Desenvolvi com o objetivo de praticar lógica de programação, estrutura de dados (listas), persistência em JSON e organização de código em C#.

---

## 🚀 Funcionalidades

- Criar conta com nome e senha
- Login com autenticação
- Depósito e saque
- Ver saldo
- Encerrar conta
- Salvamento automático dos dados em arquivo JSON (`contas.json`)

---

## 🛠️ Tecnologias e recursos usados

- Linguagem: **C#**
- Plataforma: `.NET`
- Persistência: **System.Text.Json**
- Armazenamento local: arquivo `.json`
- Execução: Terminal / Console

---

## 📁 Estrutura do projeto

```bash
CaixaEletronico/
│
├── Program.cs            # Contém o menu principal e as funcionalidades
├── ContaBancaria.cs      # Classe com as operações da conta
├── contas.json           # Armazena os dados das contas (gerado automaticamente)
└── CaixaEletronico.csproj
