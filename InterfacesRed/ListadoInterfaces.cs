using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

namespace InterfacesRed
{
    class ListadoInterfaces
    {
        public static void Ejecutar()
        {
            Console.Title = "Listado de interfaces de red y sus datos básicos";

            // NetworkInterface para obtener las interfaces de red
            NetworkInterface[] adaptadores = NetworkInterface.GetAllNetworkInterfaces();

            Console.WriteLine($"\nInterfaces de red detectadas: {adaptadores.Length}\n");

            // Itera sobre cada interfaz de red
            foreach (NetworkInterface adaptador in adaptadores)
            {
                Console.WriteLine("-------------------------------------------------------------");

                Console.WriteLine($"Descripción: {adaptador.Description}");
                Console.WriteLine($"Nombre: {adaptador.Name}");
                Console.WriteLine($"Tipo: {adaptador.NetworkInterfaceType}");

                Console.Write("Estado: ");
                if (adaptador.OperationalStatus == OperationalStatus.Up)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{adaptador.OperationalStatus} (Activa)");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{adaptador.OperationalStatus} (Inactiva)");
                }
                Console.ResetColor();

                string macAddress = adaptador.GetPhysicalAddress().ToString();
                if (!string.IsNullOrEmpty(macAddress) && macAddress != "000000000000")
                {
                    macAddress = Regex.Replace(macAddress, ".{2}", "$0:").TrimEnd(':');
                    Console.WriteLine($"Dirección MAC: {macAddress}");
                }
                else
                {
                    Console.WriteLine("Dirección MAC: No disponible");
                }

                try // Obtiene las direcciones IP de la interfaz.
                {
                    IPInterfaceProperties propiedadesIP = adaptador.GetIPProperties();
                    bool algunaDireccionImpresa = false;

                    foreach (UnicastIPAddressInformation ip in propiedadesIP.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"  IPv4: {ip.Address}");
                            algunaDireccionImpresa = true;
                        }
                        else if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            Console.WriteLine($"  IPv6: {ip.Address}");
                            algunaDireccionImpresa = true;
                        }
                    }

                    if (!algunaDireccionImpresa)
                    {
                        Console.WriteLine("  Sin direcciones IP asignadas");
                    }
                }
                catch (NetworkInformationException e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  Error al obtener direcciones IP: {e.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nPresione ENTER para salir...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}