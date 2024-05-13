internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();

            const string
                PREGUNTAR_OPCION_MENU = "Ingrese un número dependiendo lo que desea hacer: 1. Nueva Inscripción, 2. Obtener Estadísticas del Evento, 3. Buscar Cliente, 4. Cambiar Entrada de un Cliente, 5. Salir";
            const double
                OPCION1 = 45000,
                OPCION2 = 60000,
                OPCION3 = 30000,
                OPCION4 = 100000;
            const int
                NUEVA_INSCRIPCION = 1,
                OBTENER_ESTADISTICAS_DEL_EVENTO = 2,
                BUSCAR_CLIENTE = 3,
                CAMBIAR_ENTRADA_DE_UN_CLIENTE = 4,
                SALIR = 5;
            
            int opcionMenu, key, IDingresado, IDclienteAmodificar, tipoEntradaAcambiar, cantidadAcambiar;
            Cliente cliente = null;

        }

        static int IngresarOpcionMenu(string mensaje, int opcion1, int opcion2, int opcion3, int opcion4, int opcion5)
        {
            Console.WriteLine(mensaje);
            int respuesta = int.Parse(Console.ReadLine());
            while(respuesta != opcion1 && respuesta != opcion2 && respuesta != opcion3 && respuesta != opcion4 && respuesta != opcion5)
            {
                Console.WriteLine("Hubo un error en el ingreso. " + mensaje);
                respuesta = int.Parse(Console.ReadLine());
            }
            return respuesta;
        }

        static int IngresarNumeroNatural(string mensaje)
        {
            Console.WriteLine(mensaje);
            int num = int.Parse(Console.ReadLine());
            while(num < 0)
            {
                Console.WriteLine("Hubo un error en el ingreso. " + mensaje);
                num = int.Parse(Console.ReadLine());
            }

            return num;
        }

        static string IngresarString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        static double IngresarFecha(string mensaje)
        {
            Console.WriteLine(mensaje);
            double fecha = double.Parse(Console.ReadLine());
            return fecha;
        }

        static int IngresarTipoEntrada(string mensaje)
        {
            Console.WriteLine(mensaje);
            int tipoEntrada = int.Parse(Console.ReadLine());
            while(tipoEntrada != 1 && tipoEntrada != 2 && tipoEntrada != 3 && tipoEntrada != 4)
            {
                Console.WriteLine("Hubo un error en el ingreso. " + mensaje);
                tipoEntrada = int.Parse(Console.ReadLine());
            }
            return tipoEntrada;
        }
        static Cliente ObtenerCliente()
        {
            int dni = IngresarNumeroNatural("Ingrese su DNI:");
            string apellido = IngresarString("Ingrese su apellido:");
            string nombre = IngresarString("Ingrese su nombre:");
            double fechaInscripcion = IngresarFecha("Ingrese la fecha de inscripción:");
            int tipoEntrada = IngresarTipoEntrada("Ingrese el tipo de entrada: ");
            int cantidad = IngresarNumeroNatural("Ingrese la cantidad:");

            Cliente cliente = new Cliente(dni, apellido, nombre, fechaInscripcion, tipoEntrada, cantidad);

            return cliente;
        }

        static void MostrarEstadisticasEvento(Dictionary<int, Cliente> DicClientes, double precioEntradaOpcion1, double precioEntradaOpcion2, double precioEntradaOpcion3, double precioEntradaOpcion4)
        {
            double porcentajeEntradasVendidas = 0;
            int ventasOpcion1 = 0, ventasOpcion2 = 0 , ventasOpcion3 = 0, ventasOpcion4 = 0, cantEntradasCompradasOP1 = 0, cantEntradasCompradasOp2 = 0, cantEntradasCompradasOp3 = 0, cantEntradasCompradasOp4 = 0;
            foreach(Cliente cliente in DicClientes.Values)
            {
                porcentajeEntradasVendidas++;
                if(cliente.TipoEntrada == 1)
                    {
                        ventasOpcion1++;
                        cantEntradasCompradasOP1 += cliente.Cantidad;
                    }
                else if(cliente.TipoEntrada == 2)
                    {
                        ventasOpcion2++;
                        cantEntradasCompradasOp2 += cliente.Cantidad;
                    }
                else if(cliente.TipoEntrada == 3)
                    {
                        ventasOpcion3++;
                        cantEntradasCompradasOp3 += cliente.Cantidad;
                    }
                else
                    {
                        ventasOpcion4++;
                        cantEntradasCompradasOp4 += cliente.Cantidad;
                    }
            }
            porcentajeEntradasVendidas = 100 / porcentajeEntradasVendidas;
            double recaudacionTotal = ventasOpcion1 * precioEntradaOpcion1 * cantEntradasCompradasOP1 + ventasOpcion2 * precioEntradaOpcion2 * cantEntradasCompradasOp2 + ventasOpcion3 * precioEntradaOpcion3 * cantEntradasCompradasOp3 + ventasOpcion4 * precioEntradaOpcion4 * cantEntradasCompradasOp4;
            Console.WriteLine("La cantidad de clientes inscriptos es: " + DicClientes.Keys.Count);
            Console.WriteLine("La cantidad de clientes que compraron cada entrada fueron: ");
            Console.WriteLine($"- Opcion1: {ventasOpcion1} con un %{porcentajeEntradasVendidas * ventasOpcion1} respecto al total. Su recaudación fue de ${ventasOpcion1 * precioEntradaOpcion1 * cantEntradasCompradasOP1}.");
            Console.WriteLine($"- Opcion2: {ventasOpcion2} con un %{porcentajeEntradasVendidas * ventasOpcion2} respecto al total. Su recaudación fue de ${ventasOpcion2 * precioEntradaOpcion2 * cantEntradasCompradasOp2}.");
            Console.WriteLine($"- Opcion3: {ventasOpcion3} con un %{porcentajeEntradasVendidas * ventasOpcion3} respecto al total.Su recaudación fue de ${ventasOpcion3 * precioEntradaOpcion3 * cantEntradasCompradasOp3}.");
            Console.WriteLine($"- Opcion4: {ventasOpcion4} con un %{porcentajeEntradasVendidas * ventasOpcion4} respecto al total.Su recaudación fue de ${ventasOpcion4 * precioEntradaOpcion4 * cantEntradasCompradasOp4}.");
            Console.WriteLine($"La recaudación total fue de : ${recaudacionTotal}.");
        }

        static void MostrarInformacionCliente(Cliente cliente)
        {
            Console.WriteLine("Su DNI es: " + cliente.DNI);
            Console.WriteLine("Su nombre es: " + cliente.Nombre);
            Console.WriteLine("Su apellido es: " + cliente.Apellido);
            Console.WriteLine("Su fecha de inscripción es: " + cliente.FechaInscripcion);
            Console.WriteLine("El tipo de entrada que compró fue: " + cliente.TipoEntrada);
            Console.WriteLine("La cantidad de entradas que compró fue: " + cliente.Cantidad);
        }

    }