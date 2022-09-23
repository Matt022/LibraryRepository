

using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;

namespace Library.Core.Abstractions
{
    public interface IRentalEntryService
    {
        List<RentalEntry> GetAllEntries();

        RentalEntry Rent(Title title, Member member);

        RentalEntry Return(RentalEntry entry);

        List<RentalEntry> GetByUnreturnedMember(int memberId);

        decimal CalculateReturnalFee(RentalEntry entry);

        List<RentalEntry> GetRentalEntriesPastDue();

        bool IsEntryPastDue(RentalEntry entry);

        bool CanRent(Member member, Title title, out string errorMessage);

        bool CanProlongRental(RentalEntry entry, out string errorMessage);

        bool ProlongRental(RentalEntry entry);

    }
}
