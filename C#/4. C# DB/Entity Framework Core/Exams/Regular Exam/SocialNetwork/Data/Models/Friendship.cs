using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Data.Models;

[PrimaryKey(nameof(UserOneId), nameof(UserTwoId))]
public class Friendship
{
    [ForeignKey(nameof(UserOne))]
    public int UserOneId { get; set; }

    public virtual User UserOne { get; set; } = null!;

    [ForeignKey(nameof(UserTwo))]
    public int UserTwoId { get; set; }

    public virtual User UserTwo { get; set; } = null!;
}
