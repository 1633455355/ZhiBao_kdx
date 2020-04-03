<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inbox.aspx.cs" Inherits="member_inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb">
            <li><i class="icon-home home-icon"></i><a href="home.aspx">首页</a> </li>
            <li class="active">消息</li>
        </ul>
        <!-- .breadcrumb -->
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>收件箱</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="tabbable">
                    

                    <div class="tab-content no-border no-padding">
                        <div class="tab-pane in active">
                            <div class="message-container">
                                <div class="message-navbar align-center clearfix" id="id-message-list-navbar">
                                    <div class="message-bar">
                                        <div id="id-message-infobar" class="message-infobar">
                                            <span class="blue bigger-150">收件箱</span>
                                            <span class="grey bigger-110" id="unread_lb"></span>
                                        </div>

                                        <div class="message-toolbar hide">
                                            <a class="btn btn-xs btn-message" href="#" onclick="DeleteMessage()">
                                                <i class="icon-trash bigger-125"></i>
                                                <span class="bigger-110">删除</span>
                                            </a>
                                        </div>
                                    </div>

                                    <div>
                                        <div class="messagebar-item-left">
                                            <label class="inline middle">
                                                <input type="checkbox" class="ace" id="id-toggle-all">
                                                <span class="lbl"></span>
                                            </label>
                                        </div>




                                    </div>
                                </div>

                                <div class="hide message-navbar align-center clearfix" id="id-message-item-navbar">
                                    <div class="message-bar">
                                        <div class="message-toolbar">
                                            <div class="inline position-relative align-left">
                                                <a data-toggle="dropdown" class="btn-message btn btn-xs dropdown-toggle" href="#">
                                                    <span class="bigger-110">Action</span>

                                                    <i class="icon-caret-down icon-on-right"></i>
                                                </a>

                                                <ul class="dropdown-menu dropdown-lighter dropdown-caret dropdown-125">
                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-mail-reply blue"></i>
                                                            &nbsp; Reply
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-mail-forward green"></i>
                                                            &nbsp; Forward
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-folder-open orange"></i>
                                                            &nbsp; Archive
                                                        </a>
                                                    </li>

                                                    <li class="divider"></li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-eye-open blue"></i>
                                                            &nbsp; Mark as read
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-eye-close green"></i>
                                                            &nbsp; Mark unread
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-flag-alt red"></i>
                                                            &nbsp; Flag
                                                        </a>
                                                    </li>

                                                    <li class="divider"></li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-trash red bigger-110"></i>
                                                            &nbsp; Delete
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <div class="inline position-relative align-left">
                                                <a data-toggle="dropdown" class="btn-message btn btn-xs dropdown-toggle" href="#">
                                                    <i class="icon-folder-close-alt bigger-110"></i>
                                                    <span class="bigger-110">Move to</span>

                                                    <i class="icon-caret-down icon-on-right"></i>
                                                </a>

                                                <ul class="dropdown-menu dropdown-lighter dropdown-caret dropdown-125">
                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-stop pink2"></i>
                                                            &nbsp; Tag#1
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-stop blue"></i>
                                                            &nbsp; Family
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-stop green"></i>
                                                            &nbsp; Friends
                                                        </a>
                                                    </li>

                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-stop grey"></i>
                                                            &nbsp; Work
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <a class="btn btn-xs btn-message" href="#">
                                                <i class="icon-trash bigger-125"></i>
                                                <span class="bigger-110">Delete</span>
                                            </a>
                                        </div>
                                    </div>

                                    <div>
                                        <div class="messagebar-item-left">
                                            <a class="btn-back-message-list" href="#">
                                                <i class="icon-arrow-left blue bigger-110 middle"></i>
                                                <b class="bigger-110 middle">Back</b>
                                            </a>
                                        </div>

                                        <div class="messagebar-item-right">
                                            <i class="icon-time bigger-110 orange middle"></i>
                                            <span class="time grey">Today, 7:15 pm</span>
                                        </div>
                                    </div>
                                </div>

                                <div class="hide message-navbar align-center clearfix" id="id-message-new-navbar">
                                    <div class="message-bar">
                                        <div class="message-toolbar">
                                            <a class="btn btn-xs btn-message" href="#">
                                                <i class="icon-save bigger-125"></i>
                                                <span class="bigger-110">Save Draft</span>
                                            </a>

                                            <a class="btn btn-xs btn-message" href="#">
                                                <i class="icon-remove bigger-125"></i>
                                                <span class="bigger-110">Discard</span>
                                            </a>
                                        </div>
                                    </div>

                                    <div class="message-item-bar">
                                        <div class="messagebar-item-left">
                                            <a class="btn-back-message-list no-hover-underline" href="#">
                                                <i class="icon-arrow-left blue bigger-110 middle"></i>
                                                <b class="middle bigger-110">Back</b>
                                            </a>
                                        </div>

                                        <div class="messagebar-item-right">
                                            <span class="inline btn-send-message">
                                                <button class="btn btn-sm btn-primary no-border" type="button">
                                                    <span class="bigger-110">Send</span>

                                                    <i class="icon-arrow-right icon-on-right"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="message-list-container">
                                    <div id="message-list" class="message-list">
                                        
                                    </div>
                                </div>
                                <!-- /.message-list-container -->

                                <div class="message-footer clearfix">
                                    <div class="pull-left" id="total_lb">共：0 条消息 </div>

                                    <div class="pull-right">
                                        <div class="inline middle" id="page_lb"></div>

                                        &nbsp; &nbsp;
																<ul class="pagination middle">
                                                                    <li id="firstli">
                                                                        <span>
                                                                            <i class="icon-step-backward middle"></i>
                                                                        </span>
                                                                    </li>

                                                                    <li id="preli">
                                                                        <span>
                                                                            <i class="icon-caret-left bigger-140 middle"></i>
                                                                        </span>
                                                                    </li>


                                                                    <li id="nextli">
                                                                        <a href="#" onclick="GoNext()">
                                                                            <i class="icon-caret-right bigger-140 middle"></i>
                                                                        </a>
                                                                    </li>

                                                                    <li id="lastli">
                                                                        <a href="#" onclick="GoLast()">
                                                                            <i class="icon-step-forward middle"></i>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                    </div>
                                </div>

                                <div class="hide message-footer message-footer-style2 clearfix">
                                    <div class="pull-left">simpler footer </div>

                                    <div class="pull-right">
                                        <div class="inline middle">message 1 of 151 </div>

                                        &nbsp; &nbsp;
																<ul class="pagination middle">
                                                                    <li class="disabled">
                                                                        <span>
                                                                            <i class="icon-angle-left bigger-150"></i>
                                                                        </span>
                                                                    </li>

                                                                    <li>
                                                                        <a href="#">
                                                                            <i class="icon-angle-right bigger-150"></i>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                    </div>
                                </div>
                            </div>
                            <!-- /.message-container -->
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-content -->
                </div>
                <!-- /.tabbable -->
            </div>
            <!-- /.col -->
        </div>
    </div>
    <script type="text/javascript">
        jQuery(function ($) {

            //handling tabs and loading/displaying relevant messages and forms
            //not needed if using the alternative view, as described in docs
            var prevTab = 'inbox'
            $('#inbox-tabs a[data-toggle="tab"]').on('show.bs.tab', function (e) {
                var currentTab = $(e.target).data('target');
                if (currentTab == 'write') {
                    Inbox.show_form();
                }
                else {
                    if (prevTab == 'write')
                        Inbox.show_list();

                    //load and display the relevant messages 
                }
                prevTab = currentTab;
            })



            //basic initializations
            $('.message-list .message-item input[type=checkbox]').removeAttr('checked');
            $('.message-list').delegate('.message-item input[type=checkbox]', 'click', function () {
                $(this).closest('.message-item').toggleClass('selected');
                if (this.checked) Inbox.display_bar(1);//display action toolbar when a message is selected
                else {
                    Inbox.display_bar($('.message-list input[type=checkbox]:checked').length);
                    //determine number of selected messages and display/hide action toolbar accordingly
                }
            });


            //check/uncheck all messages
            $('#id-toggle-all').removeAttr('checked').on('click', function () {
                if (this.checked) {
                    Inbox.select_all();
                } else Inbox.select_none();
            });

            //select all
            $('#id-select-message-all').on('click', function (e) {
                e.preventDefault();
                Inbox.select_all();
            });

            //select none
            $('#id-select-message-none').on('click', function (e) {
                e.preventDefault();
                Inbox.select_none();
            });

            //select read
            $('#id-select-message-read').on('click', function (e) {
                e.preventDefault();
                Inbox.select_read();
            });

            //select unread
            $('#id-select-message-unread').on('click', function (e) {
                e.preventDefault();
                Inbox.select_unread();
            });

            /////////

            





            //back to message list
            $('.btn-back-message-list').on('click', function (e) {
                e.preventDefault();
                Inbox.show_list();
                $('#inbox-tabs a[data-target="inbox"]').tab('show');
            });



            //hide message list and display new message form
            /**
            $('.btn-new-mail').on('click', function(e){
                e.preventDefault();
                Inbox.show_form();
            });
            */




            var Inbox = {
                //displays a toolbar according to the number of selected messages
                display_bar: function (count) {
                    if (count == 0) {
                        $('#id-toggle-all').removeAttr('checked');
                        $('#id-message-list-navbar .message-toolbar').addClass('hide');
                        $('#id-message-list-navbar .message-infobar').removeClass('hide');
                    }
                    else {
                        $('#id-message-list-navbar .message-infobar').addClass('hide');
                        $('#id-message-list-navbar .message-toolbar').removeClass('hide');
                    }
                }
                ,
                select_all: function () {
                    var count = 0;
                    $('.message-item input[type=checkbox]').each(function () {
                        this.checked = true;
                        $(this).closest('.message-item').addClass('selected');
                        count++;
                    });

                    $('#id-toggle-all').get(0).checked = true;

                    Inbox.display_bar(count);
                }
                ,
                select_none: function () {
                    $('.message-item input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');
                    $('#id-toggle-all').get(0).checked = false;

                    Inbox.display_bar(0);
                }
                ,
                select_read: function () {
                    $('.message-unread input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');

                    var count = 0;
                    $('.message-item:not(.message-unread) input[type=checkbox]').each(function () {
                        this.checked = true;
                        $(this).closest('.message-item').addClass('selected');
                        count++;
                    });
                    Inbox.display_bar(count);
                }
                ,
                select_unread: function () {
                    $('.message-item:not(.message-unread) input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');

                    var count = 0;
                    $('.message-unread input[type=checkbox]').each(function () {
                        this.checked = true;
                        $(this).closest('.message-item').addClass('selected');
                        count++;
                    });

                    Inbox.display_bar(count);
                }
            }

            //show message list (back from writing mail or reading a message)
            Inbox.show_list = function () {
                $('.message-navbar').addClass('hide');
                $('#id-message-list-navbar').removeClass('hide');

                $('.message-footer').addClass('hide');
                $('.message-footer:not(.message-footer-style2)').removeClass('hide');

                $('.message-list').removeClass('hide').next().addClass('hide');
                //hide the message item / new message window and go back to list
            }

            //show write mail form
            Inbox.show_form = function () {
                if ($('.message-form').is(':visible')) return;
                if (!form_initialized) {
                    initialize_form();
                }


                var message = $('.message-list');
                $('.message-container').append('<div class="message-loading-overlay"><i class="icon-spin icon-spinner orange2 bigger-160"></i></div>');

                setTimeout(function () {
                    message.next().addClass('hide');

                    $('.message-container').find('.message-loading-overlay').remove();

                    $('.message-list').addClass('hide');
                    $('.message-footer').addClass('hide');
                    $('.message-form').removeClass('hide').insertAfter('.message-list');

                    $('.message-navbar').addClass('hide');
                    $('#id-message-new-navbar').removeClass('hide');


                    //reset form??
                    $('.message-form .wysiwyg-editor').empty();

                    $('.message-form .ace-file-input').closest('.file-input-container:not(:first-child)').remove();
                    $('.message-form input[type=file]').ace_file_input('reset_input');

                    $('.message-form').get(0).reset();

                }, 300 + parseInt(Math.random() * 300));
            }




            var form_initialized = false;
            function initialize_form() {
                if (form_initialized) return;
                form_initialized = true;

                //intialize wysiwyg editor
                $('.message-form .wysiwyg-editor').ace_wysiwyg({
                    toolbar:
                    [
                        'bold',
                        'italic',
                        'strikethrough',
                        'underline',
                        null,
                        'justifyleft',
                        'justifycenter',
                        'justifyright',
                        null,
                        'createLink',
                        'unlink',
                        null,
                        'undo',
                        'redo'
                    ]
                }).prev().addClass('wysiwyg-style1');

                //file input
                $('.message-form input[type=file]').ace_file_input()
                //and the wrap it inside .span7 for better display, perhaps
                .closest('.ace-file-input').addClass('width-90 inline').wrap('<div class="row file-input-container"><div class="col-sm-7"></div></div>');

                //the button to add a new file input
                $('#id-add-attachment').on('click', function () {
                    var file = $('<input type="file" name="attachment[]" />').appendTo('#form-attachments');
                    file.ace_file_input();
                    file.closest('.ace-file-input').addClass('width-90 inline').wrap('<div class="row file-input-container"><div class="col-sm-7"></div></div>')
                    .parent(/*.span7*/).append('<div class="action-buttons pull-right col-xs-1">\
							<a href="#" data-action="delete" class="middle">\
								<i class="icon-trash red bigger-130 middle"></i>\
							</a>\
						</div>').find('a[data-action=delete]').on('click', function (e) {
						    //the button that removes the newly inserted file input
						    e.preventDefault();
						    $(this).closest('.row').hide(300, function () {
						        $(this).remove();
						    });
						});
                });
            }//initialize_form


            //turn the recipient field into a tag input field!
            /**	
            var tag_input = $('#form-field-recipient');
            if(! ( /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase())) ) 
                tag_input.tag({placeholder:tag_input.attr('placeholder')});
        
        
            //and add form reset functionality
            $('.message-form button[type=reset]').on('click', function(){
                $('.message-form .message-body').empty();
                
                $('.message-form .ace-file-input:not(:first-child)').remove();
                $('.message-form input[type=file]').ace_file_input('reset_input');
                
                
                var val = tag_input.data('value');
                tag_input.parent().find('.tag').remove();
                $(val.split(',')).each(function(k,v){
                    tag_input.before('<span class="tag">'+v+'<button class="close" type="button">&times;</button></span>');
                });
            });
            */

        });
    </script>
    <script src="../js/inbox.js"></script>
    <asp:HiddenField ID="deletepermission" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#menumessage").addClass("active open");
            $("#menumessagelist").addClass("active");
        });
    </script>
</asp:Content>



