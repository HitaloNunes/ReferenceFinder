# ReferenceFinder

Uma api simples criada a partir do JSON disponibilizado pelo Thiago Bodruk (https://github.com/thiagobodruk) no projeto https://github.com/thiagobodruk/biblia.
<br /><br />***Agora também disponível no prefixo: _https://referencial.azurewebsites.net_***

Tem as funções de buscar um texto a partir de referência escrita e também a partir de trechos.

## Instruções e Recomendações
Atualmente, a API está contando com dois Endpoints:

* /Reference/buscarReferencia* <br />
* /Reference/buscarTrecho* <br />

Os dois receberão um json a partir do método POST
### Endpoint _buscarReferencia_
As referências são padronizadas, todas seguindo o padrão de: [Abreviação do nome do Livro]<espaço>[Número do capítulo]:[Número do Versículo / Números dos Versículos separados por vírgula e sem espaço]

#### Exemplos
* Jo 3:16<br />
* Sl 23:4,6<br />
* Lc 14:25,26,27<br />

#### Alguns cuidados a serem tomados

1. Jo = João<br>Jó = Jó
2. Livros numéricos (I Reis, II Reis...) representam seu índice por algarismos mesmo (1Rs, 2Rs)
3. A versão presente até o momento é a Almeida Corrigida e Fiel (ACF)

### Endpoint _buscarTrecho_
1. O endpoint foi melhorado para receber qualquer sentença de palavra. Sem distinção de letras maiúsculas ou minúsculas.

## Release Notes
### 19/10/2021
* **Branch: AdaptacaoPesquisa** <br />
Os objetos foram criados para que o retorno da API agora fosse serializado. Sendo transmitidos a partir do JSON, foi possível implementar a pesquisa por texto.

### 21/10/2021
* **Branch: _Sem Branch, não houveram muitas atualizações no código_** <br />
Após alguns testes (muitos... vejam aí na timelime de commits), consegui subir a API para o Azure! Agora temos domínio online disponível até algum momento no espaço tempo (não sei até quando, mas já está online). Neste caso, todos os Endpoints devem ser precedidos de: _https://referencial.azurewebsites.net_
