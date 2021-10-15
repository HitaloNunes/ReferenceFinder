# ReferenceFinder

Uma api simples criada a partir do JSON disponibilizado pelo Thiago Bodruk (https://github.com/thiagobodruk) no projeto https://github.com/thiagobodruk/biblia

Tem uma única função de buscar um texto a partir de uma referência escrita.

## Instruções e Recomendações
As referências são padronizadas, todas seguindo o padrão de: [Abreviação do nome do Livro]<espaço>[Número do capítulo]:[Número do Versículo / Números dos Versículos separados por vírgula e sem espaço]

### Exemplos
* Jo 3:16<br />
* Sl 23:4,6<br />
* Lc 14:25,26,27<br />

### Alguns cuidados a serem tomados

1. Jo = João<br>Jó = Jó
2. Livros numéricos (I Reis, II Reis...) representam seu índice por algarismos mesmo (1Rs, 2Rs)
3. A versão presente até o momento é a Almeida Corrigida e Fiel (ACF)
