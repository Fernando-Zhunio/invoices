using invoices.Models;
using Microsoft.EntityFrameworkCore;

namespace invoices
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> address { get; set; }
        public DbSet<Attachment> attachments { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<ItemInvoice> itemInvoice { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Sku> sku { get; set; }
        public DbSet<TaxAndDiscount> taxAndDiscounts { get; set; }
        public DbSet<TaxAndDiscountConditional> taxAndDiscountConditionals { get; set; }
        public DbSet<TypeAttachment> typeAttachments { get; set; }
        public DbSet<TypeVariation> typeVariations { get; set; }
        public DbSet<Variation> variations { get; set; }

    }
}
