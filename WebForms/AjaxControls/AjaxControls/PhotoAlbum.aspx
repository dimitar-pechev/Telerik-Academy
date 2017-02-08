<%@ Page Title="Photo Album" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="AjaxControls.PhotoAlbum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccl" %>

<asp:Content ID="PhotoAlbum" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <h1 class="text-center">Gallery-Mallery</h1>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:ListView runat="server" ID="ListViewImages" ItemType="AjaxControls.GalleryImage">
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="col-md-3">
                            <a data-toggle="modal" data-target="#GalleryModal" class="cursor-pointer image-anchor">
                                <div class="thumbnail image-container">
                                    <img class="image img-responsive" src="<%#: Item.Url %>" alt="<%#: Item.Name %>" />
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="modal fade" id="GalleryModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:Image ImageUrl="/Images/Gallery/1.jpg" ID="Image1" runat="server" CssClass="img-responsive" />
                    <ccl:SlideShowExtender runat="server" ID="SlideShowExtender" TargetControlID="Image1"
                        SlideShowServiceMethod="GetImages" NextButtonID="BtnNext" PreviousButtonID="BtnPrevious"
                        AutoPlay="false" Loop="true" />
                    <asp:ImageButton ImageUrl="/Images/chevron-left.png" runat="server" ID="BtnPrevious" />
                    <asp:ImageButton ImageUrl="/Images/arrow-right-black.png" runat="server" ID="BtnNext"  />
                </div>
            </div>
        </div>
    </div>
    <script>
        $('.image-anchor').on('click', (e) => {
            $('#MainContainer_Image1').attr('src', $(e.target).attr('src'));
        })
    </script>
</asp:Content>

