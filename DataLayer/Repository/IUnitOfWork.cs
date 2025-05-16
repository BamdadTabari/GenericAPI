namespace DataLayer;
public interface IUnitOfWork : IDisposable
{
    IBlogCategoryRepository BlogCategoryRepository { get; }
    IBlogRepository BlogRepository { get; }
    INewsletterRepository NewsletterRepository { get; }
    IOrderRepository OrderRepository { get; }
    IContactRepository ContactRepository { get; }
    IOtpRepository OtpRepository { get; }
    ITokenBlacklistRepository TokenBlacklistRepository { get; }
    IUserRepo UserRepository { get; }
    IUserRoleRepo UserRoleRepository { get; }
    IRoleRepo RoleRepository { get; }
    IBasketRepository BasketRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    IRolePermissionRepository RolePermissionRepository { get; }
    IAboutUsPageRepository AboutUsPageRepository { get; }
    IChairRepository ChairRepository { get; }
    ICityRepository CityRepository { get; }
    ICollectionRepository CollectionRepository { get; }
    IConcertRepository ConcertRepository { get; }
    IContactPageRepository ContactPageRepository { get; }
    IDiscountRepository DiscountRepository { get; }
    IDynamicEmailRepository DynamicEmailRepository { get; }
    IDynamicSmsRepository DynamicSmsRepository { get; }
    IExecutiveRolesRepository ExecutiveRolesRepository { get; }
    IHallRepository HallRepository { get; }
    IMainPageRepository MainPageRepository { get; }
    ISansRepository SansRepository { get; }
    ISponsorRepository SponsorRepository { get; }
    ITicketRepository TicketRepository { get; }
    IOptionRepository OptionRepository { get; }
    ISaleManRepository SaleManRepository { get; }
    IProvinceNewsletterRepository ProvinceNewsletterRepository { get; }
    IProvinceRepository ProvinceRepository { get; }
    IStoryRepository StoryRepository { get; }
    IConcertCategoryRepository ConcertCategoryRepository { get; }
	ISansChairRepository SansChairRepository { get; }
	Task<bool> CommitAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        BlogCategoryRepository = new BlogCategoryRepository(_context);
        BlogRepository = new BlogRepository(_context);
        NewsletterRepository = new NewsletterRepository(_context);
        OrderRepository = new OrderRepository(_context);
        ContactRepository = new ContactRepository(_context);
        OtpRepository = new OtpRepository(_context);
        TokenBlacklistRepository = new TokenBlacklistRepo(_context);
        BasketRepository = new BasketRepository(_context);
        UserRepository = new UserRepo(_context);
        UserRoleRepository = new UserRoleRepo(_context);
        RoleRepository = new RoleRepo(_context);
        PermissionRepository = new PermissionRepository(_context);
        RolePermissionRepository = new RolePermissionRepository(_context);
        AboutUsPageRepository = new AboutUsPageRepository(_context);
        ChairRepository = new ChairRepository(_context);
        CityRepository = new CityRepository(_context);
        CollectionRepository = new CollectionRepository(_context);
        ConcertRepository = new ConcertRepository(_context);
        ContactPageRepository = new ContactPageRepository(_context);
        DiscountRepository = new DiscountRepository(_context);
        DynamicEmailRepository = new DynamicEmailRepository(_context);
        DynamicSmsRepository = new DynamicSmsRepository(_context);
        ExecutiveRolesRepository = new ExecutiveRolesRepository(_context);
        HallRepository = new HallRepository(_context);
        MainPageRepository = new MainPageRepository(_context);
        SansRepository = new SansRepository(_context);
        SponsorRepository = new SponsorRepository(_context);
        TicketRepository = new TicketRepository(_context);
        OptionRepository = new OptionRepository(_context);
        ProvinceNewsletterRepository = new ProvinceNewsletterRepository(_context);
        SaleManRepository = new SaleManRepository(_context);
        ProvinceRepository = new ProvinceRepository(_context);
        StoryRepository = new StoryRepository(_context);
        ConcertCategoryRepository = new ConcertCategoryRepository(_context);
		SansChairRepository = new SansChairRepository(_context);
	}

    public IBlogCategoryRepository BlogCategoryRepository { get; }
    public IBlogRepository BlogRepository { get; }
    public INewsletterRepository NewsletterRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IContactRepository ContactRepository { get; }
    public IOtpRepository OtpRepository { get; }
    public ITokenBlacklistRepository TokenBlacklistRepository { get; }
    public IUserRepo UserRepository { get; }
    public IUserRoleRepo UserRoleRepository { get; }
    public IRoleRepo RoleRepository { get; }
    public IBasketRepository BasketRepository { get; }
    public IPermissionRepository PermissionRepository { get; set; }
    public IRolePermissionRepository RolePermissionRepository { get; set; }
    public IAboutUsPageRepository AboutUsPageRepository { get; set; }
    public IChairRepository ChairRepository { get; set; }
    public ICityRepository CityRepository { get; set; }
    public ICollectionRepository CollectionRepository { get; set; }
    public IConcertRepository ConcertRepository { get; set; }
    public IContactPageRepository ContactPageRepository { get; set; }
    public IDiscountRepository DiscountRepository { get; set; }
    public IDynamicEmailRepository DynamicEmailRepository { get; set; }
    public IDynamicSmsRepository DynamicSmsRepository { get; set; }
    public IExecutiveRolesRepository ExecutiveRolesRepository { get; set; }
    public IHallRepository HallRepository { get; set; }
    public IMainPageRepository MainPageRepository { get; set; }
    public ISansRepository SansRepository { get; set; }
    public ISponsorRepository SponsorRepository { get; set; }
    public ITicketRepository TicketRepository { get; set; }
    public IOptionRepository OptionRepository { get; set; }
    public IProvinceNewsletterRepository ProvinceNewsletterRepository { get; set; }
    public ISaleManRepository SaleManRepository { get; set; }
	public IProvinceRepository ProvinceRepository { get; set; }
    public IStoryRepository StoryRepository { get; set; }
    public IConcertCategoryRepository ConcertCategoryRepository { get; set; }
	public ISansChairRepository SansChairRepository { get; set; }
	public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;

    // dispose and add to garbage collector
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}