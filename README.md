# Gateway de Pagamentos - API RESTful com ASP.NET

Esta é uma Web API RESTful desenvolvida em ASP.NET que atua como um Gateway de Pagamentos. Atualmente, integra-se com o Mercado Pago para processamento de pagamentos via Pix, Google Pay, cartão de crédito e cartão de débito.

## Funcionalidades Principais

- **Integração com Mercado Pago:** Permite pagamentos utilizando várias formas de pagamento suportadas pelo Mercado Pago.
- **Processamento de Pagamentos:** Facilita o processo completo de pagamento do início ao fim.
- **Consulta de Status de Pagamento:** Permite verificar o status de um pagamento utilizando o método HTTP GET.

## Tecnologias Utilizadas

- **ASP.NET Core:** Framework utilizado para o desenvolvimento da API.
- **C#:** Linguagem de programação principal.
- **Entity Framework Core:** Utilizado para acesso e manipulação de dados.
- **Swagger:** Documentação e interface interativa da API.
- **Mercado Pago SDK:** SDK oficial utilizado para integração com o Mercado Pago.

## Endpoints Disponíveis

- **GET /api/pagamentos/{id}**
  - Descrição: Obtém o status de um pagamento específico.
  - Parâmetros de URL: `id` (string) - Identificador único do pagamento.
  - Resposta: Retorna detalhes do pagamento, incluindo status e informações adicionais.

- **POST /api/pagamentos**
  - Descrição: Inicia um novo pagamento.
  - Corpo da Requisição: JSON contendo detalhes do pagamento (exemplo: método de pagamento, valor, descrição).
  - Resposta: Retorna o resultado da tentativa de pagamento, incluindo um identificador único para consulta de status posteriormente.

## Configuração

Para utilizar esta API, siga os passos abaixo:

1. Clone o repositório: `git clone https://github.com/seu-usuario/nome-do-repositorio.git`
2. Configure as chaves de API necessárias para o Mercado Pago no arquivo `appsettings.json`.
3. Compile e execute a aplicação.

## Exemplo de Uso

### Iniciando um Pagamento

```http
POST /api/pagamentos
Content-Type: application/json

{
  "metodoPagamento": "pix",
  "valor": 100.00,
  "descricao": "Compra de exemplo"
}
```

### Consultando o Status de um Pagamento

```http
GET /api/pagamentos/{id}
```

Substitua `{id}` pelo identificador retornado ao iniciar o pagamento.
