*** CONFIGURAÇÕES ***
1 - login e a senha podem ser configurados no arquivo appsettings.json (linhas 3 e 4)
2 - Além do login e senha devem ser configurados a chave secreta para a geração do JWT e o tempo de duração do Token.  
3 - escolher o tipo de persistência na linha 37 do arquivo startup (CardEntityRepository ou CardListRepositoty)
	

*** OBSERVAÇÕES ***

Requisito 2 (middleware que valide se o token JWT é correto, valido e não está expirado) - Fiz a implementação seguindo uma solução sugerida pelo André Baltieri (Balta.io). Eu entendo como funciona authenticação por JWT, porém no meu trabalho tenho usado muito o Identity e no momento não domino a uma implementação JWT, por isso segui esse modelo de implementação, o qual foi resoluto. Coloquei a medida de tempo do token em segundos, para que fique fácil testar um token vencido.

Requisito 3 (login e senha em variáveis de ambiente) - As informações são injetada na classe SettingsAuthentication pela linha 41 da classe Startup.cs, e depois a classe SettingsAuthentication é injetada no construtor da controller AuthController, o que permite enviar as configurações do appsettings.json->LoginSettings para a classe que cria o token (AuthController linha 31).

Requisito 6 ( título, conteúdo e nome da lista devem estar preenchidos senão retornar status 400) - Não acredito que seja o ideal criar anotations no modelo por conta de acoplamentos, etc, porém como não criei viewModels ou classes DTOs por conta da simplicidade do sistema, utilizei a anotation [required] diretamente no modelo pois ela já retorna o status code 400(badRequest) quando é passado um valor vazio para a propriedade anotada.

Requisito 10 (criara alguma forma de persistência) - Criei duas formas, IList e EntityFramework In-Memory, as quais podem ser escolhidas na linha 37 do arquivo startup (CardListRepositoty ou CardEntityRepository). Fiz essas duas formas para demonstrar como é possível criar desacoplamento quando implementamos para uma Interface (SOLID), não gosto de realizar chamadas para as classes de banco diretamente da Controller, porém como é um projeto simples e fiz essa solução de desacoplamento através de uma interface, acredito que ficou desacolplado o suficiente.