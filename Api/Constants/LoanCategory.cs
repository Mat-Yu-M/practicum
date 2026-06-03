namespace Api.Constants
{
    public enum LoanCategory
    {
        // --- Consumer / Retail Loans ---

        /// <summary> Loans for purchasing real estate, primary residences, or land (Mortgages). </summary>
        Housing,

        /// <summary> Financing for new or used personal vehicles (Cars, motorcycles, boats). </summary>
        Vehicle,

        /// <summary> Unsecured loans for general personal expenses (medical, travel, debt consolidation). </summary>
        Personal,

        /// <summary> Funding for higher education, tuition, and student living expenses. </summary>
        Education,

        // --- Commercial / Business Loans ---

        /// <summary> Short-term financing to fund day-to-day business operations and inventory. </summary>
        WorkingCapital,

        /// <summary> Loans for purchasing business equipment, machinery, or technology. </summary>
        EquipmentFinancing,

        /// <summary> Mortgages for commercial properties, warehouses, or office spaces. </summary>
        CommercialRealEstate,

        /// <summary> Large-scale financing for infrastructure, energy, or massive industrial builds. </summary>
        ProjectFinance,

        // --- Specialized / Agriculture Loans ---

        /// <summary> Loans tailored for farmers for seed, tractor purchases, or livestock. </summary>
        Agricultural,

        /// <summary> Micro-loans aimed at entrepreneurs or low-income individuals in developing sectors. </summary>
        Microfinance,

        // --- Credit Lines ---

        /// <summary> Revolving credit lines (like credit cards or personal lines of credit). </summary>
        RevolvingCredit
    }
}
