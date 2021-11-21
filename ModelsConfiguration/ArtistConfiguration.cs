using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODULE4HW6.Models;

namespace MODULE4HW6.ModelsConfiguration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(i => i.ArtistId);
            builder.Property(i => i.ArtistId).HasColumnName("ArtistId").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
            builder.Property(i => i.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
            builder.Property(i => i.Phone).HasColumnName("Phone");
            builder.Property(i => i.Email).HasColumnName("Email");
            builder.Property(i => i.InstagramUrl).HasColumnName("InstagramUrl");

            builder.HasData(
                new Artist
                {
                    ArtistId = 1, Name = "Artur", DateOfBirth = new DateTime(1990, 10, 20), Phone = "05055333",
                    Email = "asd@aa.aa", InstagramUrl = "instagram.com/artur" },
                new Artist
                {
                    ArtistId = 2, Name = "Artur1", DateOfBirth = new DateTime(1990, 9, 11), Phone = "0339393",
                    Email = "asd@aa.aa11", InstagramUrl = "instagram.com/artur1" },
                new Artist
                {
                    ArtistId = 3, Name = "Artur2", DateOfBirth = new DateTime(1990, 9, 11), Phone = "0339393",
                    Email = "asd@aa.aa22", InstagramUrl = "instagram.com/artur2" },
                new Artist
                {
                    ArtistId = 4, Name = "Artur3", DateOfBirth = new DateTime(1989, 8, 8), Phone = "023283",
                    Email = "asd@aa.aa33", InstagramUrl = "instagram.com/artur3" },
                new Artist
                {
                    ArtistId = 5, Name = "Artur14", DateOfBirth = new DateTime(1989, 7, 10), Phone = "123823",
                    Email = "asd@aa.aa44", InstagramUrl = "instagram.com/artur4" }
            );
        }
    }
}