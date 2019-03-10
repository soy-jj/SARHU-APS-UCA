﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bonos.aspx.cs" Inherits="SARHU.Views.Nomina.bonos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div id="page-wrapper">
      <div class="row">
           <div class="col-lg-12">
                <h1 class="page-header">Listado de Bonos</h1>
                <a href="agregar-bono.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Bono</a>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Descripción</th>
                                    <th>C$ Monto</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>Bono escolar</td>
                                    <td>Buscar útiles escolares para los niños y niñas.</td>
                                    <td>C$ 5,000</td>
                                    <td align="center">
                                      <a data-toggle="modal" data-target="#mediumModal"  type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Bono"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-bono.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Bono"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Bono"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>

                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>Bono navideño</td>
                                    <td> Brindarle a los empleados algo extra para navidad.</td>
                                    <td>C$ 10,000</td>
                                    <td align="center">
                                       <a data-toggle="modal" data-target="#mediumModal"  type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Bono"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-bono.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Bono"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Bono"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>

                                </tr>
                            </tbody>
                        </table>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>

    </div>

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Bono</h2>
                   
                </div>
                <div class="modal-body">

                    <div id="page-wrapper1">
                        <div class="row">
                        <div class="col-md-6 col-md-offset-6">
        <div class="panel panel-formulario">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label>Nombre</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Bono escolar" disabled="" >
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea" disabled="" ReadOnly>Buscar útiles escolares para los niños y niñas.</textarea>
                            </div>
                             <div>
                                <label>Monto</label>
                            </div>

                            <div class="form-group input-group" style="width: 100%;">
                                <span class="input-group-addon">C$</span>
                                <input class="form-control" id="Monto" type="text" value="5,000" disabled="">
                            </div>

                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
     </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>

                    </div>

                </div>

            </div>
        </div>
        </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button style="font-size:30px" type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">¡Atención!</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Está seguro que desea borrar "Bono escolar"?
                                        </div>
                                        <div class="modal-footer">
                                            <button  onclick="DeletePopup()" data-dismiss="modal" type="button" class="btn btn-danger fondo-rojo-aldeas">Borrar</button>
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button> 
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
     </div>
    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    Borrado correctamente
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script>
        function ShowPopup() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function DeletePopup() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

       
            $('#closemodal').click(function () {
                $('#mymodal').modal('hide');
           
        });
    </script>
</asp:Content>
