<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathinfo}");

        ///Login
        routes.MapPageRoute("AdminPanelLogin",
                            "AdminPanel/Login",
                            "~/AdminPanel/LogIn.aspx");
        
        
        ///Register
        routes.MapPageRoute("AdminPanelRegister",
                            "AdminPanel/Register",
                            "~/AdminPanel/Register.aspx");
        
        ///Default
        routes.MapPageRoute("AdminPanelDefaultList",
                            "AdminPanel/Home",
                            "~/AdminPanel/Default.aspx");
        
        ///Country

        routes.MapPageRoute("AdminPanelCountryList",
                            "AdminPanel/Country/List",
                            "~/AdminPanel/Country/CountryList.aspx");

        routes.MapPageRoute("AdminPanelCountryAdd",
                            "AdminPanel/Country/{OperationName}",
                            "~/AdminPanel/Country/CountryAddEdit.aspx");

        routes.MapPageRoute("AdminPanelCountryEdit",
                            "AdminPanel/Country/{OperationName}/{CountryID}",
                            "~/AdminPanel/Country/CountryAddEdit.aspx");
        
        
        ///State
        routes.MapPageRoute("AdminPanelStateList",
                            "AdminPanel/State/List",
                            "~/AdminPanel/State/StateList.aspx");

        routes.MapPageRoute("AdminPanelStateAdd",
                            "AdminPanel/State/{OperationName}",
                            "~/AdminPanel/State/StateAddEdit.aspx");

        routes.MapPageRoute("AdminPanelStateEdit",
                            "AdminPanel/State/{OperationName}/{StateID}",
                            "~/AdminPanel/State/StateAddEdit.aspx");
        
        
        ///City
        routes.MapPageRoute("AdminPanelCityList",
                            "AdminPanel/City/List",
                            "~/AdminPanel/City/CityList.aspx");

        routes.MapPageRoute("AdminPanelCityAdd",
                            "AdminPanel/City/{OperationName}",
                            "~/AdminPanel/City/CityAddEdit.aspx");

        routes.MapPageRoute("AdminPanelCityEdit",
                            "AdminPanel/City/{OperationName}/{CityID}",
                            "~/AdminPanel/City/CityAddEdit.aspx");
        

        ///ContactCategory
        routes.MapPageRoute("AdminPanelContactCategoryList",
                            "AdminPanel/ContactCategory/List",
                            "~/AdminPanel/ContactCategory/ContactCategoryList.aspx");

        routes.MapPageRoute("AdminPanelContactCategoryAdd",
                            "AdminPanel/ContactCategory/{OperationName}",
                            "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        routes.MapPageRoute("AdminPanelContactCategoryEdit",
                            "AdminPanel/ContactCategory/{OperationName}/{ContactCategoryID}",
                            "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        
        ///Contact
        routes.MapPageRoute("AdminPanelContactList",
                            "AdminPanel/Contact/List",
                            "~/AdminPanel/Contact/ContactList.aspx");

        routes.MapPageRoute("AdminPanelContactAdd",
                            "AdminPanel/Contact/{OperationName}",
                            "~/AdminPanel/Contact/ContactAddEdit.aspx");

        routes.MapPageRoute("AdminPanelContactEdit",
                            "AdminPanel/Contact/{OperationName}/{ContactID}",
                            "~/AdminPanel/Contact/ContactAddEdit.aspx");
        
    }
</script>
