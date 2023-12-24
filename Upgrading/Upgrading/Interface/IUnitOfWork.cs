﻿namespace Upgrading.Interface
{
    public interface IUnitOfWork
    {
        IApplicationUser User { get; }
        IStudent Student { get; }
        ISubject Subject { get; }
        IAnnouncement Announcement { get; }
        IProduct Product { get; }
        void Save();
    }
}
