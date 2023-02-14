# Boas-vindas ao repositório do projeto Tryitter

Projeto realizado pelos alunos Gabriel Pinheiro e Marcela Silva para o desafio final da Aceleração de C# realizada pela escola [Trybe](https://github.com/tryber).

A dupla escolheu fazer o Tema 1 sugerido.
<br>
<br>

## Contexto

A Trybe decidiu desenvolver sua própria rede social, a Tryitter, pois ela terá características próximas à estrutura de uma outra rede social já existente, o Twitter. Totalmente baseada em texto. O objetivo é proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.

Nessa rede social, as pessoas estudantes devem conseguir se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. Deve ser possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

Uma pessoa estudante deve poder também publicar posts em seu perfil, que poderão conter texto com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos seus posts ou apenas o último.

O grupo ficou responsável pelo desenvolvimento do Back-End dessa rede social. Que recebera muitas requisições, que, por sua vez, será responsável por manter as informações atualizadas em um banco de dados MySQL Server usando o Framework Entity. Além disso, tudo deve ser disponibilizado na nuvem pela Azure.

<br>

### Desenvolvimento

<details>
<summary>Arquitetura sugerida</summary><br />

![Imagem da interação do Front com o Back-End](https://content-assets.betrybe.com/prod/Arquitetura%20do%20Tema%201.jpeg)
</details>
<details>
<summary>Alguns pontos a que a equipe deve se atentar são:</summary>

- Esse serviço recebe muitas requisições, então cuidado para não travar o servidor e deixar outras requisições esperando;
- Algumas rotas devem ser autenticadas por motivos de segurança;
- As principais funcionalidades do Back-End devem ter testes para garantir que sejam de boa manutenção.
</details>

<details><summary>Tecnologias utilizadas</summary>

- Tecnologia uzada foi o ASP .NET com C#  
- Para realização dos testes: as bibliotecas xUnit e FluentAssertions.as bibliotecas xUnit, FluentAssertions
</details>

<details><summary>Testes e Cobertura</summary>

Para executar os testes com o .NET, execute o comando dentro do diretório do projeto src/Tryitter ou dos testes src/Tryitter.Test.
```
dotnet test
```

<br>

### Para rodar o projeto na sua máquina
<details><summary>Passo a passo para instalar o projeto</summary>

```
git clone git@github.com:GabrielPinheiroMatiucci/Projeto-Final-Aceleracao-CSharp-Tema-1.git

```

```
cd src
```

```
dotnet restore
```

</details>

<br>

# Requisitos

<details>
<summary><strong>Requisitos sugeridos</strong></summary>

1. [ ] Utilizar C#, SQL Server e Azure;
2. [ ] Ter rotas autenticadas e rotas anônimas;
3. [ ] Utilizar os frameworks xUnit e FluentAssertions para criar testes.
</details>

<details>
<summary><strong>Funcionalidades</strong></summary>

1. [ ] Implementar um C.R.U.D. para as contas de pessoas estudantes;
2. [ ] Implementar um C.R.U.D. para um post de uma pessoa estudante;
3. [ ] Alterar um post depois de publicado.
</details>

<details>
<summary><strong>Extra</strong></summary>

4. [ ] Implementar três endpoints referentes à publicação de posts:
   1. [ ] Inserir um post;
   2. [ ] Listar todos os seus posts;
   3. [ ] Listar o último post.
5. [ ] Implementar dois endpoints referentes à procura de posts em outras contas:
   1. [ ] Listar todos os posts de uma conta x;
   2. [ ] Listar o último post de uma conta x.
</details>
<br>


# Termos e acordos

Ao iniciar este projeto, a dupla concorda com as diretrizes do Código de Conduta e do Manual da Pessoa Estudante da Trybe.
