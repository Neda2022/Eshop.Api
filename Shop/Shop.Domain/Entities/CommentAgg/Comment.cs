﻿using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.CommentAgg;

public class Comment:AggregateRoot
    {
    

    public long UserId { get; private set; }
    public long ProductId { get; private set; }
    public string Text { get; private set; }
    public CommentStatus Status { get; private set; }
    public DateTime UpdateDate { get; private set; }

    private Comment()
    {
            
    }
    public Comment(long userId, long productId, string text)
    {
        NullOrEmtyDomainDataException.CheckString(text, nameof(text));
        UserId = userId;
        ProductId = productId;
        Text = text;
        Status = CommentStatus.Pending;
    }

    public void Edit(string text)
    {
        NullOrEmtyDomainDataException.CheckString(text, nameof(text));
        Text = text;
        UpdateDate = DateTime.Now;
    }

    public void ChangeStatus(CommentStatus status)
    {
       Status=status;
       UpdateDate = DateTime.Now;
    }
}


