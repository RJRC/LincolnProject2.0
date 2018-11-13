﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace AccessDataLayer
{
    public class ADL
    {

        private LincolnDBEntities database = new LincolnDBEntities();

        public List<Login> getUsers()
        {
            List<Login> users = database.Login.ToList();
            return users;
        }


        public void changePassword(String user, String password)
        {
            Login login = database.Login.Single(u => u.UserName == user);
            login.PasswordLogin = password;
            database.SaveChanges();
        }

        public void changeUserName(String user)
        {
            Login login = database.Login.Single(u => u.UserName == user);
            login.UserName = user;
            database.SaveChanges();
        }

        public DataTable showSummaryMonth() {
            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string monthNumber = DateTime.Now.ToString("MM");
            string realMonth = getMonth(monthNumber);
            var summary = database.proc_SummaryPerMonth(realMonth, year);

            int monthNumberToFor = transformMonthToNumber(realMonth);
            DataTable table = new DataTable();
            table.Columns.Add("Notario");

            table.Columns.Add("Facturación Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Limite Mensual"); //Limite Mensual + Carry

            table.Columns.Add("Monto Acarreado Actual");

            foreach (proc_SummaryPerMonth_Result item in summary.ToList()) {

                /*Acarreo Proceso*/
                int montoAcarreado = 0;


                for (int i = 1; i < monthNumberToFor + 1; i++)
                {
                    string monthToSearch = "";
                    monthToSearch = getMonthNumberWithoutCeroToMonth((i + ""));

                    var variable = database.proc_Get_ActualBillingByMonth(monthToSearch, year, item.Codigo);
                    foreach (int actualBillingInMonthLessOne in variable.ToList())
                    {
                        montoAcarreado += actualBillingInMonthLessOne;
                    }
                }

                table.Rows.Add(item.Notario, "$" + item.Facturado, "$" + item.Saldo_Actual, "$" + item.Saldo_Mensual, "$" + montoAcarreado);
            }

            return table;

        }



        public DataTable showSummaryMonth(String month, int year) {


            var summary = database.proc_SummaryPerMonth(month, year);

            int monthNumber = transformMonthToNumber(month);
            DataTable table = new DataTable();
            table.Columns.Add("Notario");
            table.Columns.Add("Facturación Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Limite Mensual"); //Limite Mensual + Carry

            table.Columns.Add("Monto Acarreado Actual");

            foreach (proc_SummaryPerMonth_Result item in summary.ToList())
            {
                /*Acarreo Proceso*/
                int montoAcarreado = 0;


                for (int i = 1; i < monthNumber + 1; i++)
                {
                    /*Conseguir el mes {*/
                    string monthToSearch = "";
                    monthToSearch = getMonthNumberWithoutCeroToMonth((i + ""));

                    var variable = database.proc_Get_ActualBillingByMonth(monthToSearch, year, item.Codigo);
                    foreach (int actualBillingInMonth in variable.ToList())
                    {
                        montoAcarreado += actualBillingInMonth;
                    }


                }

                table.Rows.Add(item.Notario, "$" + item.Facturado, "$" + item.Saldo_Actual, "$" + item.Saldo_Mensual, "$" + montoAcarreado);
            }

            return table;
        }

        private int transformMonthToNumber(String month) {
            int var = 0;
            switch (month)
            {
                case "Enero":
                    var = 1;
                    break;
                case "Febrero":
                    var = 2;
                    break;
                case "Marzo":
                    var = 3;
                    break;
                case "Abril":
                    var = 4;
                    break;
                case "Mayo":
                    var = 5;
                    break;
                case "Junio":
                    var = 6;
                    break;
                case "Julio":
                    var = 7;
                    break;
                case "Agosto":
                    var = 8;
                    break;
                case "Setiembre":
                    var = 9;
                    break;
                case "Octubre":
                    var = 10;
                    break;
                case "Noviembre":
                    var = 11;
                    break;
                case "Diciembre":
                    var = 12;
                    break;
            }
            return var;
        }

        private String getMonth(String month) {
            String var = "";
            switch (month)
            {
                case "01":
                    var = "Enero";
                    break;
                case "02":
                    var = "Febrero";
                    break;
                case "03":
                    var = "Marzo";
                    break;
                case "04":
                    var = "Abril";
                    break;
                case "05":
                    var = "Mayo";
                    break;
                case "06":
                    var = "Junio";
                    break;
                case "07":
                    var = "Julio";
                    break;
                case "08":
                    var = "Agosto";
                    break;
                case "09":
                    var = "Setiembre";
                    break;
                case "10":
                    var = "Octubre";
                    break;
                case "11":
                    var = "Noviembre";
                    break;
                case "12":
                    var = "Diciembre";
                    break;

            }

            return var;
        }


        private String getMonthNumberWithoutCeroToMonth(String number)
        {
            String var = "";
            switch (number)
            {
                case "1":
                    var = "Enero";
                    break;
                case "2":
                    var = "Febrero";
                    break;
                case "3":
                    var = "Marzo";
                    break;
                case "4":
                    var = "Abril";
                    break;
                case "5":
                    var = "Mayo";
                    break;
                case "6":
                    var = "Junio";
                    break;
                case "7":
                    var = "Julio";
                    break;
                case "8":
                    var = "Agosto";
                    break;
                case "9":
                    var = "Setiembre";
                    break;
                case "10":
                    var = "Octubre";
                    break;
                case "11":
                    var = "Noviembre";
                    break;
                case "12":
                    var = "Diciembre";
                    break;

            }

            return var;
        }

        public DataTable showSummaryYear() {
            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);
            var summary = database.proc_SummaryMonths(realMonth, year);
            DataTable table = new DataTable();
            table.Columns.Add("Notario");

            table.Columns.Add("Facturación Anual");
            table.Columns.Add("Saldo Anual");
            table.Columns.Add("Limite Anual");

            foreach (proc_SummaryMonths_Result item in summary.ToList())
            {
                var movementsSummaryYear = database.proc_SummaryMovementsByNotaryID(item.NotaryID);
                int allMovements = 0;
                foreach (int item2 in movementsSummaryYear.ToList())
                {
                    allMovements = item2;
                }



                table.Rows.Add(item.Notario, "$" + allMovements, "$" + (item.Limite_Anual - allMovements), "$" + item.Limite_Anual);
            }



            return table;
        }

        public DataTable showSummaryYearPerMonths(int idNotary)
        {
            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);
            //var summary = database.proc_SummaryMonths(realMonth, year);
            DataTable table = new DataTable();
            table.Columns.Add("Mes");

            table.Columns.Add("Facturación");


            int allWritings = 0;


            for (int i = 1; i <= 12; i++)
            {
                string monthToSearch = getMonthNumberWithoutCeroToMonth((i + ""));

                var variable = database.proc_SummaryMovementsByNotaryIDAndMonth(idNotary, monthToSearch, year);

                foreach (int writing in variable.ToList())
                {
                    allWritings = writing;
                }

                if (allWritings != 0) {
                    table.Rows.Add(monthToSearch, allWritings);
                }
            }



            return table;
        }


        public DataTable showSummaryYearPerMonthsInAdminModule(int searchYear)
        {
            //int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);
            //var summary = database.proc_SummaryMonths(realMonth, year);
            DataTable table = new DataTable();
            table.Columns.Add("Iniciales");
            table.Columns.Add("Enero");
            table.Columns.Add("Febrero");
            table.Columns.Add("Marzo");
            table.Columns.Add("Abril");
            table.Columns.Add("Mayo");
            table.Columns.Add("Junio");
            table.Columns.Add("Julio");
            table.Columns.Add("Agosto");
            table.Columns.Add("Setiembre");
            table.Columns.Add("Octubre");
            table.Columns.Add("Noviembre");
            table.Columns.Add("Diciembre");

            table.Columns.Add("Total");


            int allWritings = 0;


            var list2 = database.proc_Get_Notaries();

            foreach (proc_Get_Notaries_Result item in list2.ToList()) {

                int var1 = 0;
                int var2 = 0;
                int var3 = 0;
                int var4 = 0;
                int var5 = 0;
                int var6 = 0;
                int var7 = 0;
                int var8 = 0;
                int var9 = 0;
                int var10 = 0;
                int var11 = 0;
                int var12 = 0;
                int total = 0;

                for (int i = 1; i <= 12; i++)
                {
                    string monthToSearch = getMonthNumberWithoutCeroToMonth((i + ""));

                    var variable = database.proc_SummaryMovementsByNotaryIDAndMonth(item.Codigo_Notario, monthToSearch, searchYear);

                    foreach (int writing in variable.ToList())
                    {
                        allWritings = writing;
                    }

                    switch (monthToSearch)
                    {
                        case "Enero":
                            var1 = allWritings;
                            break;
                        case "Febrero":
                            var2 = allWritings;
                            break;
                        case "Marzo":
                            var3 = allWritings;
                            break;
                        case "Abril":
                            var4 = allWritings;
                            break;
                        case "Mayo":
                            var5 = allWritings;
                            break;
                        case "Junio":
                            var6 = allWritings;
                            break;
                        case "Julio":
                            var7 = allWritings;
                            break;
                        case "Agosto":
                            var8 = allWritings;
                            break;
                        case "Setiembre":
                            var9 = allWritings;
                            break;
                        case "Octubre":
                            var10 = allWritings;
                            break;
                        case "Noviembre":
                            var11 = allWritings;
                            break;
                        case "Diciembre":
                            var12 = allWritings;
                            break;

                    }



                }

                total = var1 + var2 + var3 + var4 + var5 + var6 + var7 + var8 + var9 + var10 + var11 + var12;

                table.Rows.Add(item.Iniciales,"$" + var1, "$" + var2, "$" + var3, "$" + var4,
                    "$" + var5, "$" + var6, "$" + var7, "$" + var8,
                    "$" + var9, "$" + var10, "$" + var11, "$" + var12, "$" + total);

            }







            return table;
        }

        public int getAllMovemetsByIdNotary(int idNotary) { //Label writing
            var movementsSummaryYear = database.proc_SummaryMovementsByNotaryID(idNotary);
            int allMovements = 0;
            foreach (int item2 in movementsSummaryYear.ToList())
            {
                allMovements = item2; //Todas las escrituras de ese ID Notary
            }
            return allMovements;
        }

        public DataTable showNotaries() {
            var summary = database.proc_Get_Notaries();
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Notario");
            table.Columns.Add("Iniciales");
            table.Columns.Add("Cartula RBT");
            table.Columns.Add("Habilitado");
            table.Columns.Add("Saldo Mensual");

            foreach (proc_Get_Notaries_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Notario, item.Nombre, item.Iniciales, item.Cartula_RBT, item.Habilitado, item.Saldo_Mensual_Ideal);
            }

            return table;

        }

        public DataTable showNotariesDeleted()
        {
            var summary = database.proc_Get_Notaries_Eliminated();
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Notario");
            table.Columns.Add("Iniciales");

            foreach (proc_Get_Notaries_Eliminated_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Notario, item.Nombre, item.Iniciales);
            }

            return table;

        }

        public DataTable showCoNotaries(int idActualNotary)
        {
            var summary = database.proc_Get_NotariesWithOutOneById(idActualNotary);
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Co-Notario");


            foreach (proc_Get_NotariesWithOutOneById_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Notario, item.Nombre);

            }

            return table;

        }

        /*Filtrar por Mes*/
        public DataTable showProtocols()
        {
            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);
            var summary = database.proc_Get_ProtocolsByMonth(realMonth, year);
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Notario");
            table.Columns.Add("Saldo Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Saldo Anual");
            table.Columns.Add("Cartula RBT");
            table.Columns.Add("Habilitado");

            foreach (proc_Get_ProtocolsByMonth_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Protocolo, item.Notario, item.Saldo_Mensual_Ideal, item.Saldo_Actual, item.Saldo_Anual,
                    item.Cartula_en_RBT, item.Protocolo_disponible);
            }

            return table;

        }

        public List<proc_Get_Notaries_Result> getNotaries()
        {
            return database.proc_Get_Notaries().ToList();

        }


        public void addNotary(String name, String saldo, String rbt, String enabled, String month, String initials)
        {

            database.proc_Create_Notary(name, initials, rbt, enabled, int.Parse(saldo), int.Parse(DateTime.Now.ToString("yyyy")));
        }


        public void updateNotary(int id, String name, int saldo, String intials, String rbt, String enabled)
        {

            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);
            /*Modifica propiedades basicas del notario*/
            database.proc_Update_Notary(id, name, intials, rbt, enabled, saldo, "NO", "", year);

            /*Modifica todos los Saldos Actuales */
            for (int i = 1; i < 13; i++) {
                string month2 = getMonthNumberWithoutCeroToMonth(i + "");
                database.proc_UpdateProtocolActualBillingByMonth(id, month, year);


            }

        }



        public void deleteNotary(int id)
        {
            Notary notary = database.Notary.Single(u => u.NotaryID == id);
            notary.Eliminated = "SI";
            database.SaveChanges();
        }

        public Notary loadNotary(int id) {
            return database.Notary.Single(u => u.NotaryID == id);
        }

        public Notary loadProtocol(int id)
        {
            var info = database.proc_Get_ProtocolInfo(id);
            Notary n = new Notary();
            foreach (proc_Get_ProtocolInfo_Result item in info.ToList())
            {

                n.NotaryID = item.Codigo_Notario;
                n.NotaryName = item.Nombre;
                n.NotaryInitials = item.Iniciales;
                n.RBTEnabled = item.RBT;
                n.NotaryAvailable = item.Habilitado;
            }
            return n;
        }


        /*Cargar todas las escrituras en las que participa un notario, Ya sea Propia o Co-Notario  FALTA*/
        /*Todas las participacion de un notario en un mes */
        public DataTable loadAllWritingsByProtocol(String month, int year, int id) {
            var summary = database.proc_Get_ALLWritingsByProtocol(month, year, id);



            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Numero de Escritura");
            table.Columns.Add("Acto");
            table.Columns.Add("Asunto");
            table.Columns.Add("Cliente");
            table.Columns.Add("Honorario");
            table.Columns.Add("Partes");
            table.Columns.Add("Cedula a Facturar");
            table.Columns.Add("Domicilio a Facturar");
            table.Columns.Add("Correo a Facturar");
            table.Columns.Add("Fecha");
            table.Columns.Add("Facturado por Notario");


            foreach (proc_Get_ALLWritingsByProtocol_Result item in summary.ToList())
            {

                var totalHonorary = database.proc_HonoraryWriting(item.Codigo);
                int writingHonorary = 0;
                foreach (int item2 in totalHonorary.ToList())
                {
                    writingHonorary = item2;
                }

                if (item.Co_Notario.Equals("NO")) {
                    table.Rows.Add(item.Codigo, item.Numero_de_Escritura, item.Acto_, item.Asunto, item.Cliente, writingHonorary,
                        item.Partes, item.Cedula_a_Facturar, item.Domilicio_a_Facturar, item.Correo_a_Facturar,
                        item.Fecha, item.Facturado_por_Notario);
                }

            }

            return table;
        }


        public DataTable showCo_NotaryWritingByID(int idWriting)
        {
            var summary = database.proc_Get_Co_NotaryWritingByID(idWriting);
            DataTable table = new DataTable();

            table.Columns.Add("Codigo");
            table.Columns.Add("Acto");
            table.Columns.Add("Asunto");
            table.Columns.Add("Cliente");
            table.Columns.Add("Notario");
            table.Columns.Add("Facturado por Co-Notario");


            foreach (proc_Get_Co_NotaryWritingByID_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Escritura, item.Acto_, item.Asunto, item.Cliente, item.Notario,
                    item.Facturado_por_Notario);


            }

            return table;
        }


        public int checkClient(string clientname) {
            var list = database.proc_Get_Clients();
            foreach (proc_Get_Clients_Result item in list.ToList()) {

                if (item.Nombre_del_Cliente.Equals(clientname)) {
                    return item.Codigo;
                }
            }
            return -1;
        }

        public int createClient(string clientname) {
            var list = database.proc_Create_Client(clientname);
            foreach (int item in list.ToList()) {
                return item;
            }
            return -1;
        }

        public int checkAffair(string affair)
        {
            var list = database.proc_Get_Affairs();
            foreach (proc_Get_Affairs_Result item in list.ToList())
            {

                if (item.Asunto.Equals(affair))
                {
                    return item.Codigo;
                }
            }
            return -1;
        }

        public int createAffair(string affair)
        {
            return database.proc_Create_Affair(affair);
        }


        public void createWriting(int clientID, int protocolID, int affairID, String billingNumber,
            String billingAddress, string billingEmail, DateTime date, string eventWriting, int billingAmount,
            string parts, string writingNumber) {

            database.proc_Create_Writing(clientID, protocolID, affairID, billingNumber, billingAddress, billingEmail,
                date, eventWriting, billingAmount, parts, writingNumber);

        }

        public void createMovement(int protocolID, int billingAmount) {


            var list = database.proc_Get_LastWriting();
            int idWriting = 0;
            foreach (int i in list.ToList()) {
                idWriting = i;
            }


            database.proc_Create_Movement(protocolID, idWriting, billingAmount);

        }

        public int getProtocolByMonthAndYear(int idNotary, string month, int year) {
            var list = database.proc_Get_ProtocolIDByMonthAndYear(month, year, idNotary);

            foreach (int i in list.ToList()) {

                return i;
            }
            return 0;
        }


        public List<int> getYears() {
            var list = database.proc_Get_Years();

            List<int> listOfYears = new List<int>();
            foreach (int item in list.ToList()) {
                listOfYears.Add(item);
            }

            return listOfYears;
        }

        
    }
}
