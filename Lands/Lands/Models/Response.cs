namespace Lands.Models
{
    //CLASE QUE NOS AYUDARA A COMSUMIR EL SERVICIO
  public class Response
    {
        //
        public bool IsSuccess
        {  get; set; }
        //
        public string Message
        { get;
          set;
        }

        //
        public object Result
        { get;  set;  }

    }

}
