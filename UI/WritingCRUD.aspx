﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWriting.Master" AutoEventWireup="true" CodeBehind="WritingCRUD.aspx.cs" Inherits="UI.WritingCRUD" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">

<!-- //css files -->

<link rel="stylesheet" href="css/font-awesomeBox.css"> <!-- Font-Awesome-Icons-CSS -->
    <link href="css/writingCrud.css" rel="stylesheet" />
    <link href="css/searchStyles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-right: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
    <form id="form2" runat="server">


         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             
     <div class="contact" id="contact">
		<div class="container">
            
			<h3 class="title"><asp:Label ID="LabelName"  runat="server" Text=""></asp:Label> - <asp:Label ID="LabelInitials"  runat="server" Text=""></asp:Label></h3> <!-- Nombre del Notario y Iniciales  -->
            
            <h4>  <asp:Label ID="LabelRBT"   runat="server" Text="" style="color:red"> </asp:Label>  PUEDE CARTULAR RBT</h4>
           <br/>
            <h4>  <asp:Label ID="LabelAvailable"   runat="server" Text="" style="color:red"> </asp:Label>  SE ENCUENTRA HABILITADO</h4>
           
            <br/>
            <asp:Button ID="ButtonNewWriting" class="btn btn-lg btn-warning" runat="server" Text="Crear Nueva Escritura" OnClick="ButtonNewWriting_Click" />

	      
            <br/>
            <br/>
                


            
		</div>
	</div>



      

     <div class="" id="about">
		<div class="container">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                 <ContentTemplate> 

                <h3 class="title">Total Facturado Año Fiscal $<asp:Label ID="LabelTotalYear" runat="server" Text="Label"></asp:Label>
			</h3>

	      
            <br/>
            <br/>
          

                     <!--Portafolio del Mes -->

               

            <div class="table-responsive">
                <asp:GridView ID="GridViewTotalYear" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="689px" >
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
             </div>

                </ContentTemplate>  
                </asp:UpdatePanel>

            <div class="clearfix"> </div>
            <br/>
            <br/>

		</div>
	</div>


    <div class="" id="services">
		<div class="container">
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate> 
                <h3 class="title">Facturación del Mes de - <asp:Label ID="LabelMonth" runat="server" Text="Label"></asp:Label>
			</h3>
            
	      
            <br/>
            <br/>
          

                     <!--Portafolio del Mes -->



                     <div class = "searchContainer">

                <div class="">
                        <div class="col-12 col-md-10 col-lg-8">
                            <div class="card card-sm">
                                <div class="card-body row no-gutters align-items-center">
                                    
                                    <!--end of col-->
                                    <div class="col">
                                        <asp:TextBox ID="TextBoxMonth" runat="server" placeholder="Buscar por Mes " type="search" class="form-control form-control-lg form-control-borderless"></asp:TextBox>
                                        <br/>
                                        <asp:TextBox ID="TextBoxYear" runat="server" placeholder="Buscar por Año " type="search" class="form-control form-control-lg form-control-borderless"></asp:TextBox>
                                         <br/>
                                    </div>

                                   

                                    <!--end of col-->
                                    <div class="col-auto">
                                        
                                        <asp:Button ID="ButtonSearch" class="btn btn-lg btn-default" runat="server" Text="Buscar" OnClick="ButtonSearch_Click" /> 
                                         <asp:Button ID="ButtonActual" class="btn btn-lg btn-default" runat="server" Text="Mes Actual" OnClick="ButtonActual_Click" />
                                    
                                    </div>
                                    <!--end of col-->
                                </div>
                            </div>
                        </div>
                        <!--end of col-->
                    </div>

            </div>

               <div class="clearfix"> </div>
                     <br>
                     <br>

            <div class="table-responsive">
                <asp:GridView ID="GridViewMonths" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewMonths_RowCommand" OnSelectedIndexChanged="GridViewMonths_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="showCo-Notariado" Text="Co-Notariado" >
                        <ControlStyle CssClass="btn btn-default" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="UpdateWriting" Text="Modificar" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
             </div>


            <div class="table-responsive">
                <asp:GridView ID="GridViewMonthsSearch" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewMonthsSearch_RowCommand" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="showCo-Notariado" Text="Co-Notariado" >
                        <ControlStyle CssClass="btn btn-default" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" CommandName="UpdateWriting" Text="Modificar" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
             </div>
                     
                    


                </ContentTemplate>  
                </asp:UpdatePanel>

            <div class="clearfix"> </div>
            
            
		</div>
	</div>



        <div class="contact" id="">
		<div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
			<h4 class="title"><asp:Label ID="Label2"  runat="server" Text=""></asp:Label></h4> <!-- Nombre del Notario y Iniciales  -->
                     <br>
                     
                     <div class="table-responsive">
                     <asp:GridView ID="GridView1" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="688px" OnRowCommand="GridView1_RowCommand">

                         <AlternatingRowStyle BackColor="White"  />
                         <Columns>
                             <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="modifyCommand" Text="Modificar" />
                         </Columns>
                         <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                         <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                         <SortedAscendingCellStyle BackColor="#FDF5AC" />
                         <SortedAscendingHeaderStyle BackColor="#4D0000" />
                         <SortedDescendingCellStyle BackColor="#FCF6C0" />
                         <SortedDescendingHeaderStyle BackColor="#820000" />

                     </asp:GridView>
                         </div>



             </ContentTemplate>  
                </asp:UpdatePanel>
	      
            <br/>
            <br/>
                


            
		</div>
	</div>
         
    </form>
</asp:Content>
