# Clean Architecture

"es un patrón de diseño de software que estructura las aplicaciones en capas concéntricas, priorizando la independencia de frameworks, UI, bases de datos y agentes externos" Uncle Bob 

# Capa de Dominio (Domain)

La capa de dominio es aquella donde se maneja la lógica de negocio de la aplicación, en la medida de lo posible se debe evitar su modificación y es por ello que se emplean intermediarios entre el dominio y las capas esteriores donde un cambio en una framework o api puede provar alterationes en buena parte del código.

El dominio es absnóstico de lenguajes y frameworks y son solamente un conjunto de reglas establecidas al momento del añalisis del sistema.


## Entidades

Las entidades son los objetos materiales e inmateriales del sistema.

La clase de una entidad debe contener sus atributos, métodos y validaciones.

Ejemplo:

```
public class PersonEntity
{
    <!-- Atributos -->
    public GUID ID {get; set;}
    public string Code { get; private set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;

    <!-- Constructor -->
    public PersonEntity (string code, string FirstName)
    {
        validateCode(code);
        validateFirstName(firstname);

        Code = code.Trim().ToLowe();
        FirstName = firstname.Trim().ToLowe();
    }

    <!-- Metodos -->
    public string GetFullName() => $"{FirstName} {LastName}";

    <!-- Validaciones -->

    private void ValidateCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código no puede estar vaío", nameof(code));

        if (code.Trim().Length < 3)
            throw new ArgumentException("El código debe tener al menos 3 caracteres", nameof(code));

        if (code.Trim().Length > 10)
            throw new ArgumentException("El código no puede tener más de 10 caracteres", nameof(code));
    }

        private void ValidateFirstName(string firstname)
    {
        if (string.IsNullOrWhiteSpace(firstname))
            throw new ArgumentException("El nombre no puede estar vacío", nameof(firstname));
        if (firstname.Trim().Length < 2)
            throw new ArgumentException("El nombre debe tener al menos 2 caracteres", nameof(firstname));
        if (firstname.Trim().Length > 50)
            throw new ArgumentException("El nombre no puede tener más de 50 caracteres", nameof(firstname));
    }
}
```




## Interfaces (abstracciones)

Las interfaces son contratos comunes para todas las entidades del dominio. Dado que son aplicables para cualquier entidad las interfaces se definen con tipos de datos genérico 

Al crear una interfaz realmente no se escribe el código de ninguna función sino que se "declaran las funciones" que posee cada contrato


Convenciones de C#: 
- Las interfaces se escriben con I mayúscula al inicio seguida por el nombre con la primera letra también en mayúscula.
- Los tipos de datos genéricos se escriben COn T al inicio seguido por un nombre representativo con la primera letra en mayúscula


## Ejemplo:


```

public interface IRepository <TEntity, TId> where TEntity : class
   {
       Task<TEntity?> GetByIdAsync(TId id);
       Task<IEnumerable<TEntity>> GetAllAsync();
       Task AddAsync(TEntity entity);
       Task UpdateAsync(TEntity entity);
       Task DeleteAsync(TEntity entity);
       Task<int> SaveChanges();
   }
```

# Capa de casos de uso (UseCases)

La capa de casos de uso emplea los contratos de las interfaces en las  entidades declaradas en la capa de dominio.

El nombre de esta capa viene dado al hecho de que podremos o no decidir utilizar los contatos para cada entidad según sean nuestras necesidades establecidas por los casos de uso.

En esta capa aparece el concepto de inyección de dependencias el cual le quita la responsabilidad a las clases de esta capa de crear los objetos

En esta capa aparece el concepto de inyección de dependencias, una dependencia es todo componente de software externo que otro componente o programa necesita para funcionar (como las librerias).

En este caso la inyección de dependencias es decirle a al computadora que va a utilizar el contrato X con la entidad Y sin que la capa tenga que crear ni el contrato ni la entidad, únicamente recibiéndolo del exterior.

Esto es posible ya que cada capa tiene total conocimiento de su capa inmediatamente inferior y nulo conocimiento de las capas exteriores, este es un pilar clase de las arquitecturas limpias.


## Ejemplo:

```
public class DeleteByIdUseCase
{
    public readonly IRepository<PersonEntity, Guid> _repository;
    public DeleteByIdUseCase(IRepository<PersonEntity, Guid> repository)
    {
        _repository = repository;
    }
    public async Task ExecuteAsync(Guid id) 
    {
        var person = await _repository.GetByIdAsync(id);
        if (person == null)
        {
            throw new InvalidOperationException($"No se encontró a ningún usuario con Id: {id}");
        }
        await _repository.DeleteAsync(person);
        await _repository.SaveChanges();
    }
}
```

En este ejemplo se utiliza el contrato DeleteById con la entidad PersonEntity pero es perfectamente reutilizable para otraas entidades como LaptopEntity o HouseEntity.


# DTO (Data Transfer Objct):

Un DTO es un objeto intermediario cuyo objetivo es desacoplar al emisor y receptor desacoplando las api de la lógica de negocio o la base de datos permitiendo que cada una maneja únicamente la informacióm involucrada al momento de su declaración.

Aunque su uso no es estrictamente necesario para el funcionamiento del sistema sí está profundamente involucrado al ciclo de vida del software al permitir un mayor grado de adaptabilidad. Un sistema preparado para trabajar con datos X y Y puede ser facilmente expandido a datos W y Z siempre que esta expansión sea tratada mediante los DTO.


