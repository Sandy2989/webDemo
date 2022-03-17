<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webDemoFrontend._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>  
        $(document).ready(function () {
            $("#Save").click(function () {
                var person = new Object();
                person.firstName = $('#first').val();
                person.lastName = $('#last').val();
                $.ajax({
                    url: 'https://localhost:44340/api/PersonViewModels/Create',
                    type: 'POST',
                    crossDomain: true,
                    dataType: 'json',
                    data: person,
                    success: function (data, textStatus, xhr) {
                        console.log(data);
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        console.log('Error in Operation');
                    }
                });
            });
        });
    </script>  
    <div class="row">
        <div class="col-md-6">
            <div>
             <asp:TextBox ID="first" runat="server" ClientIDMode="Static" placeholder="first name"></asp:TextBox> 

            </div>
             <div >
                <asp:TextBox ID="last" ClientIDMode="Static" runat="server" placeholder="Last name" ></asp:TextBox>          

            </div>
            <div>
                <input type="button" id="Save" value="Save Data" />  
            </div>
        </div>
    </div>
    

</asp:Content>
