﻿using EventOAPI.Data;
using EventOAPI.Dto;
using EventOAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventOAPI.Services
{
    public class CommunitiesServices
    {

        private readonly EventContext context;

        public CommunitiesServices(EventContext context)
        {
            this.context = context;
        }

        public List<Community> GetAllCommunities()
        {
            return context.Communities.ToList();
        }

        public Community AddCommunity(CommunityDto community)
        {
            context.Communities.Add(new Community
            {
                UserId = community.OwnerId,
                Name = community.Name,
                IsExclusive = community.IsExclusive,
                IsPremium = community.IsPremium,
                Price = community.Price,
                CreatedAt = DateTime.Now
            });
            context.SaveChanges();
            return context.Communities.OrderBy(o => o.Id).Last();

        }

        public bool RemoveCommunity(int id)
        {
            try
            {
                var community = context.Communities.FirstOrDefault(c => c.Id == id);
                if (community != null)
                {
                    context.Communities.Remove(community);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Community UpdateCommunity(int Id, CommunityDto community)
        {
            var existingCommunity = context.Communities.Include(c => c.Members).FirstOrDefault(c => c.Id == Id);
            if (existingCommunity != null)
            {
                existingCommunity.Name = community.Name;
                existingCommunity.IsExclusive = community.IsExclusive;
                existingCommunity.IsPremium = community.IsPremium;
                existingCommunity.Price = community.Price;
                context.SaveChanges();
            }
            return existingCommunity!;
        }
        public Community GetCommunityById(int id)
        {
            return context.Communities.Include(c => c.Members).FirstOrDefault(c => c.Id == id)!;
        }

        internal bool AddMembeToCommunity(int communityId, int memberId)
        {
            var community = context.Communities.Include(c => c.Members).FirstOrDefault(c => c.Id.Equals(communityId));
            if (community != null)
            {
                community.Members.Add(new CommunityMember
                {
                    UserId = memberId,
                    CommunityId = communityId,
                    JoinedAt = DateTime.Now,

                });
                context.SaveChanges();
                return true;
            }
            return false;
        }

        internal bool RemoveMemberFromCommunity(int communityId, int memberId)
        {
            var community = context.Communities.Include(c => c.Members).FirstOrDefault(c => c.Id.Equals(communityId));
            if (community != null)
            {
                var member = community.Members.FirstOrDefault(m => m.UserId.Equals(memberId));
                community.Members.Remove(member!);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<Event> GetCommunityEvents(int communityId)
        {
            return context.Communities.Include(c => c.CommunityEvents).FirstOrDefault(c => c.Id.Equals(communityId))!.CommunityEvents.ToList();
        }

        internal bool DeleteEventFromCommunity(int communityId, int eventId)
        {

            var community = context.Communities.Include(c => c.CommunityEvents).FirstOrDefault(c => c.Id.Equals(communityId))!;
            if (community != null)
            {
                var e = community.CommunityEvents.FirstOrDefault(c => c.Id.Equals(eventId));
                community.CommunityEvents.Remove(e!);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        internal bool AddEventToCommunity(int communityId, int eventId)
        {
            var e = context.Events.FirstOrDefault(e => e.Id.Equals(eventId));
            if (e != null)
            {
                context.Communities.Include(c => c.CommunityEvents).First(c => c.Id.Equals(communityId)).CommunityEvents.Add(e);
                context.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
