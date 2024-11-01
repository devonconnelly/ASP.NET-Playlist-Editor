using AutoMapper;
using DC2247A3.Data;
using DC2247A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-0323088c-24aa-41f2-8adb-86fa66ae4b93
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace DC2247A3.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();

                cfg.CreateMap<TrackBaseViewModel, TrackWithDetailViewModel>();

                cfg.CreateMap<Track, TrackWithDetailViewModel>();

                cfg.CreateMap<TrackAddViewModel, Track>();

                cfg.CreateMap<TrackBaseViewModel, TrackAddFormViewModel>();

                cfg.CreateMap<Album, AlbumBaseViewModel>();

                cfg.CreateMap<Artist, ArtistBaseViewModel>();

                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();

                cfg.CreateMap <Playlist, PlaylistBaseViewModel>();

                cfg.CreateMap<PlaylistBaseViewModel, PlaylistEditTracksFormViewModel>();


            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var albums = mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(ds.Albums);
            return albums.OrderBy(a => a.Title);
        }

        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var artists = mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(ds.Artists);
            return artists.OrderBy(a => a.Name);
        }

        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            var mediaTypes = mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(ds.MediaTypes);
            return mediaTypes.OrderBy(m => m.Name);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
        {
            var tracks = ds.Tracks
                   .Include("Album.Artist")
                   .Include("MediaType");

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks)
                         .OrderBy(t => t.Name);
        }

        public TrackWithDetailViewModel TrackGetByIdWithDetail(int id)
        {
            var track = ds.Tracks
                          .Include("Album.Artist")
                          .Include("MediaType")
                          .SingleOrDefault(t => t.TrackId == id);

            return track == null ? null : mapper.Map<TrackWithDetailViewModel>(track);
        }

        public TrackBaseViewModel TrackAdd(TrackAddViewModel newTrack)
        {
            var album = ds.Albums.Find(newTrack.AlbumId);
            var mediaType = ds.MediaTypes.Find(newTrack.MediaTypeId);
            if (album == null || mediaType == null)
            {
                return null; 
            }

            var addedItem = mapper.Map<TrackAddViewModel, Track>(newTrack);
            addedItem.Album = album;
            addedItem.MediaType = mediaType;

            ds.Tracks.Add(addedItem);
            ds.SaveChanges();
            return mapper.Map<Track, TrackBaseViewModel>(addedItem);
        }

        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            var playlists = ds.Playlists
                .Include("Tracks");

            return mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(playlists)
                .OrderBy(p => p.Name);
        }


        public PlaylistBaseViewModel PlaylistGetById(int id)
        {
            var obj = ds.Playlists
               .Include("Tracks")
               .SingleOrDefault(p => p.PlaylistId == id);

            return obj == null ? null : mapper.Map<PlaylistBaseViewModel>(obj);
        }

        public PlaylistBaseViewModel PlaylistEditTracks(PlaylistEditTracksViewModel updatedPlaylist)
        {
            var playlist = ds.Playlists
                .Include("Tracks")
                .SingleOrDefault(p => p.PlaylistId == updatedPlaylist.PlaylistId);

            if (playlist == null)
            {
                return null;
            }

            playlist.Tracks.Clear();
            foreach (var trackId in updatedPlaylist.SelectedTrackIds)
            {
                var track = ds.Tracks.Find(trackId);
                if (track != null)
                {
                    playlist.Tracks.Add(track);
                }
            }

            ds.SaveChanges();
            return mapper.Map<Playlist, PlaylistBaseViewModel>(playlist);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            var tracks = mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks);
            return tracks.OrderBy(t => t.Name);
        }

    }
}