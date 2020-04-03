
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="roleupdate.aspx.cs" Inherits="member_roleupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">角色</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>更新角色</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-horizontal">
                    <div class="form-group" id="divtitle">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt"> 角色名称 </label>
                        <div class="col-sm-9">
                            <input type="text" placeholder="角色名称" class="col-xs-10 col-sm-5" id="title_txt" />
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="titleerr"></span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                </div>
                <div class="form-horizontal">
                    <div class="form-group" id="divcontent">
                        <label class="col-sm-3 control-label no-padding-right" for="title_txt"> 角色权限 </label>
                        <div class="col-sm-6">
                            <div class="table-responsive" >
                    <table id="sample-table-1" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>模块名称</th>
                                <th>新增</th>
                                <th>修改</th>
                                <th>删除</th>
                                <th>浏览</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>用户管理</td>
                                <td><input type="checkbox" value="1" name="YHGL" />新增</td>
                                <td><input type="checkbox" value="2" name="YHGL" />设置</td>
                                <td><input type="checkbox" value="3" name="YHGL" />删除</td>
                                <td><input type="checkbox" value="4" name="YHGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>资讯管理</td>
                                <td><input type="checkbox" value="1" name="ZXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="ZXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="ZXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="ZXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>反馈管理</td>
                                <td><input type="checkbox" value="1" name="FKXXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="FKXXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="FKXXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="FKXXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>促销管理</td>
                                <td><input type="checkbox" value="1" name="CXHDGL" />新增</td>
                                <td><input type="checkbox" value="2" name="CXHDGL" />设置</td>
                                <td><input type="checkbox" value="3" name="CXHDGL" />删除</td>
                                <td><input type="checkbox" value="4" name="CXHDGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>消息管理</td>
                                <td><input type="checkbox" value="1" name="XXGL" />新增</td>
                                <td></td>
                                <td><input type="checkbox" value="3" name="XXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="XXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>产品代码管理</td>
                                <td><input type="checkbox" value="1" name="CPDMGL" />新增</td>
                                <td><input type="checkbox" value="2" name="CPDMGL" />设置</td>
                                <td><input type="checkbox" value="3" name="CPDMGL" />删除</td>
                                <td><input type="checkbox" value="4" name="CPDMGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>角色管理</td>
                                <td><input type="checkbox" value="1" name="QXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="QXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="QXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="QXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>车型管理</td>
                                <td><input type="checkbox" value="1" name="CXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="CXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="CXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="CXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>报表管理</td>
                                <td><input type="checkbox" value="1" name="TJBBGL" />新增</td>
                                <td><input type="checkbox" value="2" name="TJBBGL" />设置</td>
                                <td><input type="checkbox" value="3" name="TJBBGL" />删除</td>
                                <td><input type="checkbox" value="4" name="TJBBGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>车主管理</td>
                                <td><input type="checkbox" value="1" name="KHGL" />新增</td>
                                <td><input type="checkbox" value="2" name="KHGL" />设置</td>
                                <td><input type="checkbox" value="3" name="KHGL" />删除</td>
                                <td><input type="checkbox" value="4" name="KHGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>渠道产品类型管理</td>
                                <td><input type="checkbox" value="1" name="CPLXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="CPLXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="CPLXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="CPLXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>工厂产品类型管理</td>
                                <td><input type="checkbox" value="1" name="GCCPLXGL" />新增</td>
                                <td><input type="checkbox" value="2" name="GCCPLXGL" />设置</td>
                                <td><input type="checkbox" value="3" name="GCCPLXGL" />删除</td>
                                <td><input type="checkbox" value="4" name="GCCPLXGL" />浏览</td>
                            </tr>
                            <tr>
                                <td>产品认证管理</td>
                                <td><input type="checkbox" value="1" name="CPRZGL" />新增</td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td>理赔管理</td>
                                <td><input type="checkbox" value="1" name="LPGL" />新增</td>
                                <td><input type="checkbox" value="2" name="LPGL" />设置</td>
                                <td><input type="checkbox" value="3" name="LPGL" />删除</td>
                                <td><input type="checkbox" value="4" name="LPGL" />浏览</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                            <span class="help-inline col-xs-12 col-sm-7"> <span class="middle" id="contenterr"></span> </span> </div>
                    </div>
                    <div class="space-4"></div>
                </div>

                
                <!-- /.table-responsive -->
            </div>
            <!-- /span -->
        </div>

        <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="UpdateRole()"> <i class="icon-ok bigger-110"></i> 更新 </button>
                        </div>
                    </div>

    </div>
    <script src="../js/jquery.query.js"></script>
    <script src="../js/roleupdate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menurole").addClass("active open");
        });
    </script>
</asp:Content>

