namespace SistemaIntegrado.Domain.Entities
{
    public class UsuarioEntity
    {
        public int? Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido  { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public int Estado { get; set; }

        public UsuarioEntity(int id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string celular, string correo, int tipoDocumento, string documento, int estado)
        {
            Id = id;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Celular = celular;
            Correo = correo;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            Estado = estado;
        }

        public UsuarioEntity(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string celular, string correo, int tipoDocumento, string documento, int estado)
        {
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Celular = celular;
            Correo = correo;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            Estado = estado;
        }
    }
}
