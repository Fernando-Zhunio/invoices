﻿namespace invoices.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        public int TypeAttachmentId { get; set; }
        public TypeAttachment TypeAttachment { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
