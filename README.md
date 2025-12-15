# Sistema-de-Informaci-n-M-dico-Integrado
Diseñar y desarrollar un Sistema de Información Médico integrado, donde cada grupo es responsable de implementar un módulo funcional completo con 2 o 3 formularios, su respectiva lógica de negocio y su conexión a SQL Server mediante ADO.NET, garantizando integración, estándares unificados y coherencia visual/técnica.

## Conexión a Base de Datos

- Cadena configurada en App.config con nombre `ClinicaProDB`.
- Ajuste si es necesario en: [Plantilla mejorada/App.config](Plantilla mejorada/App.config)
- Ejemplo (actual):

```
Data Source=DESKTOP-QN52C2T\MIPRO;Initial Catalog=ClinicaPro2;User ID=clinica_user;Password=***;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True;Connect Timeout=30
```

Reemplace `Data Source`, `User ID` y `Password` según su instancia de SQL Server. La base debe existir con nombre `ClinicaPro2`.

## Módulo 1: Gestión de Pacientes

- Repositorio: [Plantilla mejorada/DBRepository/PacienteRepository.cs](Plantilla mejorada/DBRepository/PacienteRepository.cs)
- UI: [Plantilla mejorada/Modulo1.cs](Plantilla mejorada/Modulo1.cs)

### Funcionalidades
- Listado de pacientes (JOIN con `CAT_SEGUROS`).
- Crear / Editar / Eliminar pacientes.
- Registro básico de contacto de emergencia (campo libre: "Nombre - Teléfono").
- Manejo de seguro: si escribe un nombre en "Seguro", se crea en `CAT_SEGUROS` si no existe.

### Notas de uso
- `Sexo` en UI: "Masculino/Femenino/Otro" → DB: `M/F/O`.
- `EstadoPaciente` se guarda como `Activo` por defecto.
- Campos opcionales como Email, Dirección, Celular no están en el formulario pero pueden añadirse fácilmente.

### Requisitos de tablas
Mínimo requeridas en `ClinicaPro2`:
- `CAT_SEGUROS (IdSeguro, NombreSeguro)`
- `PACIENTES (...)` con FK opcional a `CAT_SEGUROS`
- `CONTACTOS_EMERGENCIA (...)` con FK a `PACIENTES`

## Pruebas rápidas
1. Configure `App.config` con su servidor/credenciales.
2. Ejecute la app y abra el "Módulo 1".
3. Agregue un paciente (Nombre, Apellido, Cédula, Fecha, Sexo, etc.).
4. Verifique que aparece en la lista y que la eliminación funcione.
