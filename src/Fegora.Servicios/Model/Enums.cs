namespace Fegora.Servicios.Model
{
    public enum TipoItem
    {
        Bien, // por defecto
        Servicio
    }

    public enum Pais
    {
        GT, // por defecto
        AD, AE, AF, AG, AI, AL, AM, AO, AQ, AR, AS, AT, AU, AW, AX, AZ, BA, BB, BD, BE, BF, BG, BH, BI, BJ, BL, BM, BN, BO, BQ, BR, BS, BT, BV, BW, BY, BZ, CA, CC, CD, CF, CG, CH, CI, CK, CL, CM, CN, CO, CR, CU, CV, CW, CX, CY, CZ, DE, DJ, DK, DM, DO, DZ, EC, EE, EG, EH, ER, ES, ET, FI, FJ, FK, FM, FO, FR, GA, GB, GD, GE, GF, GG, GH, GI, GL, GM, GN, GP, GQ, GR, GS, GU, GW, GY, HK, HM, HN, HR, HT, HU, ID, IE, IL, IM, IN, IO, IQ, IR, IS, IT, JE, JM, JO, JP, KE, KG, KH, KI, KM, KN, KP, KR, KW, KY, KZ, LA, LB, LC, LI, LK, LR, LS, LT, LU, LV, LY, MA, MC, MD, ME, MF, MG, MH, MK, ML, MM, MO, MP, MQ, MR, MS, MT, MU, MV, MW, MX, MY, MZ, NA, NC, NE, NF, NG, NI, NL, NO, NP, NR, NU, NZ, OM, PA, PE, PF, PG, PH, PK, PL, PM, PN, PR, PS, PT, PW, PY, QA, RE, RO, RS, RU, RW, SA, SB, SC, SD, SE, SG, SH, SI, SJ, SK, SL, SM, SN, SO, SR, SS, ST, SV, SX, SY, SZ, TC, TD, TF, TG, TH, TJ, TK, TL, TM, TN, TO, TR, TT, TV, TW, TZ, UA, UG, UM, US, UY, UZ, VA, VC, VE, VG, VI, VN, VU, WF, WS, YE, YT, ZA, ZM, ZW
    }

    public enum Moneda
    {
        GTQ, ADP, AED, AFA, AFN, ALK, ALL, AMD, ANG, AOA, AOK, AON, AOR, ARA, ARP, ARS, ARY, ATS, AUD, AWG, AYM, AZM, AZN, BAD, BAM, BBD, BDT, BEC, BEF, BEL, BGJ, BGK, BGL, BGN, BHD, BIF, BMD, BND, BOB, BOP, BOV, BRB, BRC, BRE, BRL, BRN, BRR, BSD, BTN, BUK, BWP, BYB, BYN, BYR, BZD, CAD, CDF, CHC, CHE, CHF, CHW, CLF, CLP, CNX, CNY, COP, COU, CRC, CSD, CSJ, CSK, CUC, CUP, CVE, CYP, CZK, DDM, DEM, DJF, DKK, DOP, DZD, ECS, ECV, EEK, EGP, ERN, ESA, ESB, ESP, ETB, EUR, FIM, FJD, FKP, FRF, GBP, GEK, GEL, GHC, GHP, GHS, GIP, GMD, GNE, GNF, GNS, GQE, GRD, GWE, GWP, GYD, HKD, HNL, HRD, HRK, HTG, HUF, IDR, IEP, ILP, ILR, ILS, INR, IQD, IRR, ISJ, ISK, ITL, JMD, JOD, JPY, KES, KGS, KHR, KMF, KPW, KRW, KWD, KYD, KZT, LAJ, LAK, LBP, LKR, LRD, LSL, LSM, LTL, LTT, LUC, LUF, LUL, LVL, LVR, LYD, MAD, MDL, MGA, MGF, MKD, MLF, MMK, MNT, MOP, MRO, MTL, MTP, MUR, MVQ, MVR, MWK, MXN, MXP, MXV, MYR, MZE, MZM, MZN, NAD, NGN, NIC, NIO, NLG, NOK, NPR, NZD, OMR, PAB, PEH, PEI, PEN, PES, PGK, PHP, PKR, PLN, PLZ, PTE, PYG, QAR, RHD, ROK, ROL, RON, RSD, RUB, RUR, RWF, SAR, SBD, SCR, SDD, SDG, SDP, SEK, SGD, SHP, SIT, SKK, SLL, SOS, SRD, SRG, SSP, STD, SUR, SVC, SYP, SZL, THB, TJR, TJS, TMM, TMT, TND, TOP, TPE, TRL, TRY, TTD, TWD, TZS, UAH, UAK, UGS, UGW, UGX, USD, USN, USS, UYI, UYN, UYP, UYU, UZS, VEB, VEF, VNC, VND, VUV, WST, XAF, XAG, XAU, XBA, XBB, XBC, XBD, XCD, XDR, XEU, XFO, XFU, XOF, XPD, XPF, XPT, XRE, XSU, XTS, XUA, XXX, YDD, YER, YUD, YUM, YUN, ZAL, ZAR, ZMK, ZMW, ZRN, ZRZ, ZWC, ZWD, ZWL, ZWN, ZWR
    }

    public enum TipoDte
    {
        Factura, // por defecto
        FacturaEspecial,
        NotaCredito,
        NotaDebito,
        NotaAbono,
        Recibo,
        ReciboDonacion
    }
}
