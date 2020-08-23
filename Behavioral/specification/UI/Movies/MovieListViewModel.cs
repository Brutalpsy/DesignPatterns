using CSharpFunctionalExtensions;
using Logic.Movies;
using System.Collections.Generic;
using System.Windows;
using UI.Common;

namespace UI.Movies
{
    public class MovieListViewModel : ViewModel
    {
        private readonly MovieRepository _repository;

        public Command SearchCommand { get; }
        public Command<long> BuyAdultTicketCommand { get; }
        public Command<long> BuyChildTicketCommand { get; }
        public Command<long> BuyCDCommand { get; }

        public IReadOnlyList<MovieDto> Movies { get; private set; }

        public bool ForKidsOnly { get; set; }
        public double MinimumRating { get; set; }
        public bool OnCD { get; set; }

        public MovieListViewModel()
        {
            _repository = new MovieRepository();

            SearchCommand = new Command(Search);
            BuyAdultTicketCommand = new Command<long>(BuyAdultTicket);
            BuyChildTicketCommand = new Command<long>(BuyChildTicket);
            BuyCDCommand = new Command<long>(BuyCD);
        }

        private void BuyChildTicket(long movieId)
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue) return;

            var movie = movieOrNothing.Value;

            // var isSuitableForChildren = Movie.IsSuitableForChieldren.Compile();
            var specification = new MovieForKidsSpecification();
            if(!specification.IsSatisfiedBy(movie))
            {
                MessageBox.Show("Movie is not suitable for chidlren", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("You've bought a ticket.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyCD(long movieId)
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue) return;

          //  var specification = new GenericSpecification<Movie>(x => x.ReleaseDate <= DateTime.Now.AddMonths(-6));
            var specification = new AvailableOnCdSpecification();
            var movie = movieOrNothing.Value;
            if (specification.IsSatisfiedBy(movie))
            {
                MessageBox.Show("The movie doesn't have a CD version.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("You've bought a ticket.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyAdultTicket(long movieId)
        {
            MessageBox.Show("You've bought a Adult Ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search()
        {
            Specification<Movie> spec = Specification<Movie>.All;
            if (ForKidsOnly)
            {
                spec = spec.And(new MovieForKidsSpecification());
            }
            if (OnCD)
            {
                spec = spec.And(new AvailableOnCdSpecification());
            }
            //var spec = new MovieDirectedBySpecification("Marc Webb");

            Movies = _repository.GetList(spec, MinimumRating);
            Notify(nameof(Movies));
        }
    }
}
