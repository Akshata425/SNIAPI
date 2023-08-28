[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SNIAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SNIAPI.App_Start.NinjectWebCommon), "Stop")]

namespace SNIAPI.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using SNIAPI.Services.Interfaces;
    using SNIAPI.Services.PaypalService;
    using SNIAPI.Services.RepositoryService;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPaypalPayment>().To<PaypalPaymentService>();
            kernel.Bind<IRazorPayPayment>().To<RazorPaymentService>();
            
            kernel.Bind<IRazorPayPaymentSponsore>().To<RazorPaymentSponsoreService>();

            kernel.Bind<IOfflineAssessment>().To<OfflineAssessmentService>();
            kernel.Bind<IExamService>().To<ExamService>(); 
            kernel.Bind<IAccountDetails>().To<AccountDetails>();
            kernel.Bind<IMockTestService>().To<MockTestService>(); 
            kernel.Bind<IGeneralService>().To<GeneralService>();
            kernel.Bind<IFreeTestService>().To<FreeTestService>();
            kernel.Bind<IInstituteService>().To<InstituteService>();
            kernel.Bind<ILandingPageService>().To<LandingPageService>();
            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IOnlineAssessment>().To<OnlineAssessment>();
            kernel.Bind<IFacultyService>().To<FacultyService>();
            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<ISponsoreService>().To<SponsorerService>();
            kernel.Bind<ISponsoreStuService>().To<SponsoreStuService>();
            kernel.Bind<ISponsoredetailsService>().To<SponsoredetailsService>();
            kernel.Bind<IChannelpartnerService>().To<ChannelpartnerService>();
        }
    }
}