# challenge_net_jeanPereiraLourenco_JR
[FagronTech] - Challenge - { .net } 
===================

Criar uma aplicação SPA, uma api restful e um banco de dados que realizará operações crud referente a um cadastro de clientes.

-------------

Especificações Técnicas
-------------

- **Front-End**: HTML | CSS | Javascript, AngularJS, SQL 

- **Back-End**: API em C#

- **Escrita do código:** Português

- **Aplicação:** Inglês e Português (deve adaptar-se de acordo com o idioma do usuário)

- **Ferramentas**: Qualquer outras ferramentas, bibliotecas e frameworks podem ser utilizadas para facilitar o desenvolvimento, desde que a aplicação siga os requisitos acima. Ex: Bower, NodeJs, Gulp, Less, Angular Material, JQuery, Bootstrap, etc.

- **Plataforma suportada:** Chrome 

------------

Requisitos do Produto
-------------

A entidade de cliente deve ter os seguintes campos: 

----------------


Nome do Campo          |  Tipo     |   Obrigatoriedade      |   Tamanho    |          Observações
-----------------------|-----------|------------------------|--------------|-------------------------------------------------------
Id (Identificador)     | Inteiro   |	      Sim	    |	           |
Nome	               |  String   |	      Sim	    |       30	   |
Sobrenome	       |  String   |	      Sim	    |      100	   |
CPF	               |  String   |	      Sim	    |       11	   |  Deve validar o cpf, deve ter mascara
Data de nascimento     |  Data	   |          Sim	    |	           |
Idade	               |  Inteiro  |	      Sim           |	           |  Deve ser calculada a partir da data de nascimento
Profissão	       | Inteiro   |          Não	    |	           |  Deve ser selecionado em um combo com as opções                                                                                           Programador, Analista, Gerente, Estagiário e QA.

-------------

Requisitos obrigatórios
--------------

- A aplicação deverá ter uma listagem de clientes cadastrados no formato de grid.
- Para cada registro deverá ter a opção de excluir e editar o cliente. 
- Deve ter uma ação de visualizar detalhes.
- Um formulário para incluir novos clientes.
- Deverá conter validações básicas de acordo com as regras da entidade cliente.
- Não é permitido o uso de algum scaffolding.

----------

Critérios de avaliação
-------------

 - Qualidade de escrita do código
 - Organização do projeto
 - Arquitetura utilizada
 - UI e UX desing das telas
 - Adaptação do layout aos diferentes tamanhos de tela responsividade.
 - Utilização do Git (quantidade e descrição dos commits, utilização ou não de branches)
 - Padronização do código fonte (uso de boas práticas, uso de design patterns)
 - Cumprimento das especificações do teste
 - Criação de uma api para fazer o CRUD 

**Sugestão de ferramentas**                               

Notepad++, SublimeText, Visual Code, Visual Studio ou qualquer outra ferramenta que o candidato quiser desde que mencionada na descrição da solução (COMMENTS.md).

------------

Instruções de entrega
-------------

 1. Crie um fork do repositório no seu GitHub
 2. Faça o push do código desenvolvido no seu Github
 3. Inclua um arquivo chamado COMMENTS.md explicando o que foi feito
	 - Explicação rápida da decisão arquitetura utilizada e o porquê
	 - Lista de bibliotecas de teceiros utilizadas
	 - O que você melhoraria se tivesse mais tempo
	 - Quais requisitos obrigatórios não foram entregues e o porquê 
 4. Informe ao recrutador quando concluir o desafio junto com o link do repositório

**FagronTech**

**Recrutador**
  Fabio Sousa
