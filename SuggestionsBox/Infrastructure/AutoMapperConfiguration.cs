using System;
using System.Globalization;
using System.Security;
using AutoMapper;
using SuggestionsBox.Models;

namespace SuggestionsBox.Infrastructure
{
public abstract class AutoMapperConfiguration
{
    protected readonly IMapper _mapper;

    protected AutoMapperConfiguration()
    {
        try
        {
            var config = new MapperConfiguration(m =>
            {
                //for read-only model mapping
                m.CreateMap<Suggestion, SuggestionViewModel>()
                    .ForMember(x => x.DatePosted, opt => { opt.MapFrom(o => DateTime.Parse(o.DatePosted, new CultureInfo("en-CA"))); })
                    .ForMember(x => x.DateReplied, opt => { opt.MapFrom(o => DateTime.Parse(o.DateReplied, new CultureInfo("en-CA"))); }); //set date posted date;

                //for user post mapping
                m.CreateMap<UserPostViewModel, Suggestion>()
                    .ForMember(x => x.DatePosted,
                        opt => { opt.MapFrom(o => DateTime.Now); }) //set date posted date
                    .ForMember(x => x.Id, opt => opt.MapFrom(o => Guid.NewGuid())) //create new id
                    .ForMember(x => x.IsVisible, opt => { opt.MapFrom(o => false); }) // set default value
                    .ForMember(x => x.UserPost, opt => {opt.MapFrom(o=> SecurityElement.Escape(o.UserPost));})//escape invalid characters
                    .ForAllOtherMembers(x => x.Ignore());

                //for moderator mapping
                m.CreateMap<ModeratorReplyViewModel, Suggestion>()
                    .ForMember(x => x.Id, opt => { opt.MapFrom(o => o.Id); })
                    .ForMember(x => x.DateReplied,
                        opt => { opt.MapFrom(o => DateTime.Now); }) //set date replied date
                    .ForMember(x => x.IsVisible, opt => { opt.MapFrom(o => true); }) // set default value
                    .ForMember(x => x.ModeratorReply, opt => { opt.MapFrom(o => SecurityElement.Escape(o.ModeratorReply)); })//escape invalid characters
                    .ForAllOtherMembers(x => x.Ignore());
            });
            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }
        catch (Exception e)
        {
            e.Data.Add("Method Name:", "AutoMapperConfiguration()");
            LogWrapper.Log(e);
        }
    }
}

}

