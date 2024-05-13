static class Ticketera
{
    private static Dictionary <int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static double
        OP1 = 45000,
        OP2 = 60000,
        OP3 = 30000,
        OP4 = 100000;

    private static int UltimoIDEntrada = 0;

        public static int AgregarCliente(Cliente cliente)
    {
        int key = Ticketera.DevolverUltimoID();
        
        DicClientes.Add(key, cliente);
        UltimoIDEntrada = key;

        return key++;
    }

    public static Cliente BuscarCliente(int ID)
    {
        Cliente cliente = null;
        bool condicion = DicClientes.ContainsKey(ID);
        if (condicion)
        {
            cliente = DicClientes[ID];
        }
        
        return cliente;
    }

    public static bool CambiarEntrada(int ID, int Tipo, int cantidad)
    {
        Cliente cliente;
        bool condicion = DicClientes.ContainsKey(ID);
        
        if (condicion != false)
        {
            double importe = ObtenerPrecioEntrada(OP1, OP2, OP3, OP4, Tipo, cantidad);
            cliente = DicClientes[ID];
            double importeAnterior = ObtenerPrecioEntrada(OP1, OP2, OP3, OP4, cliente.TipoEntrada, cliente.Cantidad);
            if(importe < importeAnterior)
            {
                condicion = false;
            }
        }

        return condicion;
    }
    static double ObtenerPrecioEntrada(double OP1, double OP2, double OP3, double OP4, int tipo, int cantidad)
    {
        double importe = 0;
        switch (tipo)
        {
            case 1:
                importe = OP1 * cantidad;
                        break;
            case 2:
                importe = OP2 * cantidad;
                    break;
            case 3:
                importe = OP3 * cantidad;
                    break;
            case 4:
                importe = OP4 * cantidad;
                    break;
        }
        return importe;
    }
}