using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace TS.SSC.Portal.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

        


            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/moment/moment.min.js")
                .Include("~/Content/DataTables/DataTables-1.10.18/js/jquery.dataTables.min.js")
                .Include("~/Content/DataTables/FixedHeader-3.1.4/js/dataTables.fixedHeader.min.js")
                .Include("~/Content/js/plugins/moment/datetime-moment.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                //.Include("~/Content/js/plugins/icheck/icheck.js")
                //.Include("~/Content/js/plugins/validator/validator.js")
                //.Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js"));



            bundles.Add(new StyleBundle("~/Bundles/css")
            .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
            .Include("~/Content/css/bootstrap-select.css")
            .Include("~/Content/css/bootstrap-datepicker3.min.css")
            .Include("~/Content/css/custom.css")
            .Include("~/Content/DataTables/DataTables-1.10.18/css/jquery.dataTables.min.css")
            .Include("~/Content/DataTables/FixedHeader-3.1.4/css/fixedHeader.dataTables.min.css")
            .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
            .Include("~/Content/css/icheck/green.min.css", new CssRewriteUrlTransformAbsolute())
            .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
            .Include("~/Content/css/skins/skin-blue-light.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // jqueryunobtrusive includes unobtrusive-ajax but not validate.unobtrusive.
            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive")
                .Include("~/Scripts/jquery.unobtrusive*"));
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
