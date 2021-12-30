using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SettingsDAL : Database
    {
        public DataSet M_Settings_GetByBranchId(int BranchId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Settings_GetByBranchId";
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            return ExDataBase_returnDataSet(cmd);
        }

        public DataSet M_Settings_InsertOrUpdate(int BranchId, string Logo, string Site_name, string Tel, string Dateformat, string Timeformat, string Default_email,
         string Language, string Version, string Theme, string Timezone, string Protocol, string Smtp_host, string Smtp_user, string Smtp_pass,
         string Smtp_port, string Smtp_crypto, int Mmode, int Captcha, string Mailpath, string Currency_prefix, int Default_customer, string Default_tax_rate,
         int Rows_per_page, int Total_rows, string Header, string Footer, int Bsty, int Display_kb, int Default_category, string Default_discount,
         int Item_addition, string Barcode_symbology, int Pro_limit, int Decimals, string Thousands_sep, string Decimals_sep, string Focus_add_item,
         string Add_customer, string Toggle_category_slider, string Cancel_sale, string Suspend_sale, string Print_order, string Print_bill, string Finalize_sale,
         string Today_sale, string Open_hold_bills, string Close_register, int Java_applet, string Receipt_printer, string Pos_printers, string Cash_drawer_codes,
         int? Char_per_line, int? Rounding, string Pin_code, int? Stripe, string Stripe_secret_key, string Stripe_publishable_key, string Purchase_code,
         string Envato_username, string Theme_style, int? After_sale_page, int? Overselling, string Multi_store, int? Qty_decimals, string Symbol,
         int? Sac, int? Display_symbol, int? Remote_printing, int? Printer, string Order_printers, int? Auto_print, int? Local_printers, int? Rtl,
         int? Print_img, string Ws_barcode_type, int? Ws_barcode_chars, int? Flag_chars, int? Item_code_start, int? Item_code_chars, int? Price_start,
         int? Price_chars, int? Price_divide_by, int? Weight_start, int? Weight_chars, int? Weight_divide_by)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "M_POS_Settings_InsertOrUpdate";

            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@Logo", Logo);
            cmd.Parameters.AddWithValue("@Site_name", Site_name);
            cmd.Parameters.AddWithValue("@Tel", Tel);
            cmd.Parameters.AddWithValue("@Dateformat", Dateformat);
            cmd.Parameters.AddWithValue("@Timeformat", Timeformat);
            cmd.Parameters.AddWithValue("@Default_email", Default_email);
            cmd.Parameters.AddWithValue("@Language", Language);
            cmd.Parameters.AddWithValue("@Version", Version);
            cmd.Parameters.AddWithValue("@Theme", Theme);
            cmd.Parameters.AddWithValue("@Timezone", Timezone);
            cmd.Parameters.AddWithValue("@Protocol", Protocol);
            cmd.Parameters.AddWithValue("@Smtp_host", Smtp_host);
            cmd.Parameters.AddWithValue("@Smtp_user", Smtp_user);
            cmd.Parameters.AddWithValue("@Smtp_pass", Smtp_pass);
            cmd.Parameters.AddWithValue("@Smtp_port", Smtp_port);
            cmd.Parameters.AddWithValue("@Smtp_crypto", Smtp_crypto);
            cmd.Parameters.AddWithValue("@Mmode", Mmode);
            cmd.Parameters.AddWithValue("@Captcha", Captcha);
            cmd.Parameters.AddWithValue("@Mailpath", Mailpath);
            cmd.Parameters.AddWithValue("@Currency_prefix", Currency_prefix);
            cmd.Parameters.AddWithValue("@Default_customer", Default_customer);
            cmd.Parameters.AddWithValue("@Default_tax_rate", Default_tax_rate);
            cmd.Parameters.AddWithValue("@Rows_per_page", Rows_per_page);
            cmd.Parameters.AddWithValue("@Total_rows", Total_rows);
            cmd.Parameters.AddWithValue("@Header", Header);
            cmd.Parameters.AddWithValue("@Footer", Footer);
            cmd.Parameters.AddWithValue("@Bsty", Bsty);
            cmd.Parameters.AddWithValue("@Display_kb", Display_kb);
            cmd.Parameters.AddWithValue("@Default_category", Default_category);
            cmd.Parameters.AddWithValue("@Default_discount", Default_discount);
            cmd.Parameters.AddWithValue("@Item_addition", Item_addition);
            cmd.Parameters.AddWithValue("@Barcode_symbology", Barcode_symbology);
            cmd.Parameters.AddWithValue("@Pro_limit", Pro_limit);
            cmd.Parameters.AddWithValue("@Decimals", Decimals);
            cmd.Parameters.AddWithValue("@Thousands_sep", Thousands_sep);
            cmd.Parameters.AddWithValue("@Decimals_sep", Decimals_sep);
            cmd.Parameters.AddWithValue("@Focus_add_item", Focus_add_item);
            cmd.Parameters.AddWithValue("@Add_customer", Add_customer);
            cmd.Parameters.AddWithValue("@Toggle_category_slider", Toggle_category_slider);
            cmd.Parameters.AddWithValue("@Cancel_sale", Cancel_sale);
            cmd.Parameters.AddWithValue("@Suspend_sale", Suspend_sale);
            cmd.Parameters.AddWithValue("@Print_order", Print_order);
            cmd.Parameters.AddWithValue("@Print_bill", Print_bill);
            cmd.Parameters.AddWithValue("@Finalize_sale", Finalize_sale);
            cmd.Parameters.AddWithValue("@Today_sale", Today_sale);
            cmd.Parameters.AddWithValue("@Open_hold_bills", Open_hold_bills);
            cmd.Parameters.AddWithValue("@Close_register", Close_register);
            cmd.Parameters.AddWithValue("@Java_applet", Java_applet);
            cmd.Parameters.AddWithValue("@Receipt_printer", Receipt_printer);
            cmd.Parameters.AddWithValue("@Pos_printers", Pos_printers);
            cmd.Parameters.AddWithValue("@Cash_drawer_codes", Cash_drawer_codes);
            cmd.Parameters.AddWithValue("@Char_per_line", Char_per_line);
            cmd.Parameters.AddWithValue("@Rounding", Rounding);
            cmd.Parameters.AddWithValue("@Pin_code", Pin_code);
            cmd.Parameters.AddWithValue("@Stripe", Stripe);
            cmd.Parameters.AddWithValue("@Stripe_secret_key", Stripe_secret_key);
            cmd.Parameters.AddWithValue("@Stripe_publishable_key", Stripe_publishable_key);
            cmd.Parameters.AddWithValue("@Purchase_code", Purchase_code);
            cmd.Parameters.AddWithValue("@Envato_username", Envato_username);
            cmd.Parameters.AddWithValue("@Theme_style", Theme_style);
            cmd.Parameters.AddWithValue("@After_sale_page", After_sale_page);
            cmd.Parameters.AddWithValue("@Overselling", Overselling);
            cmd.Parameters.AddWithValue("@Multi_store", Multi_store);
            cmd.Parameters.AddWithValue("@Qty_decimals", Qty_decimals);
            cmd.Parameters.AddWithValue("@Symbol", Symbol);
            cmd.Parameters.AddWithValue("@Sac", Sac);
            cmd.Parameters.AddWithValue("@Display_symbol", Display_symbol);
            cmd.Parameters.AddWithValue("@Remote_printing", Remote_printing);
            cmd.Parameters.AddWithValue("@Printer", Printer);
            cmd.Parameters.AddWithValue("@Order_printers", Order_printers);
            cmd.Parameters.AddWithValue("@Auto_print", Auto_print);
            cmd.Parameters.AddWithValue("@Local_printers", Local_printers);
            cmd.Parameters.AddWithValue("@Rtl", Rtl);
            cmd.Parameters.AddWithValue("@Print_img", Print_img);
            cmd.Parameters.AddWithValue("@Ws_barcode_type", Ws_barcode_type);
            cmd.Parameters.AddWithValue("@Ws_barcode_chars", Ws_barcode_chars);
            cmd.Parameters.AddWithValue("@Flag_chars", Flag_chars);
            cmd.Parameters.AddWithValue("@Item_code_start", Item_code_start);
            cmd.Parameters.AddWithValue("@Item_code_chars", Item_code_chars);
            cmd.Parameters.AddWithValue("@Price_start", Price_start);
            cmd.Parameters.AddWithValue("@Price_chars", Price_chars);
            cmd.Parameters.AddWithValue("@Price_divide_by", Price_divide_by);
            cmd.Parameters.AddWithValue("@Weight_start", Weight_start);
            cmd.Parameters.AddWithValue("@Weight_chars", Weight_chars);
            cmd.Parameters.AddWithValue("@Weight_divide_by", Weight_divide_by);

            return ExDataBase_returnDataSet(cmd);

        }
        public DataSet M_SettingAccounts_InsertOrUpdate(int BranchId, int CachAccountId, int TaxAccountId, int SalesAccountId, int TransTypeNo, int? ExpensesTypeId, int? PaymentVoucherId)

        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "M_SettingAccounts_InsertOrUpdate";
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@CachAccountId", CachAccountId);
            cmd.Parameters.AddWithValue("@TaxAccountId", TaxAccountId);
            cmd.Parameters.AddWithValue("@SalesAccountId", SalesAccountId);
            cmd.Parameters.AddWithValue("@TransTypeNo", TransTypeNo);
            cmd.Parameters.AddWithValue("@ExpensesTypeId", ExpensesTypeId);
            cmd.Parameters.AddWithValue("@PaymentVoucherId", PaymentVoucherId);

            return ExDataBase_returnDataSet(cmd);

        }
        public DataSet GetSettingAccountsByBranchId(int BranchId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetSettingAccountsByBranchId";
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
