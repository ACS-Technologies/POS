using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class SettingsDBL
    {
        public Settings M_Settings_GetByBranchId(int BranchId)
        {
            DataSet ds = new DataSet();
            Settings oSettings = new Settings();
            SettingsDAL oSettingsDAL = new SettingsDAL();

            ds = oSettingsDAL.M_Settings_GetByBranchId(BranchId);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["BranchId"].ToString()))
                        oSettings.BranchId = int.Parse(ds.Tables[0].Rows[0]["BranchId"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Setting_id"].ToString()))
                        oSettings.Setting_id = int.Parse(ds.Tables[0].Rows[0]["Setting_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Dateformat"].ToString()))
                        oSettings.Dateformat = ds.Tables[0].Rows[0]["Dateformat"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Logo"].ToString()))
                        oSettings.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Timeformat"].ToString()))
                        oSettings.Timeformat = ds.Tables[0].Rows[0]["Timeformat"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Site_name"].ToString()))
                        oSettings.Site_name = ds.Tables[0].Rows[0]["Site_name"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Tel"].ToString()))
                        oSettings.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_email"].ToString()))
                        oSettings.Default_email = ds.Tables[0].Rows[0]["Default_email"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Language"].ToString()))
                        oSettings.Language = ds.Tables[0].Rows[0]["Language"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Version"].ToString()))
                        oSettings.Version = ds.Tables[0].Rows[0]["Version"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Theme"].ToString()))
                        oSettings.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Timezone"].ToString()))
                        oSettings.Timezone = ds.Tables[0].Rows[0]["Timezone"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Protocol"].ToString()))
                        oSettings.Protocol = ds.Tables[0].Rows[0]["Protocol"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_host"].ToString()))
                        oSettings.Smtp_host = ds.Tables[0].Rows[0]["Smtp_host"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_user"].ToString()))
                        oSettings.Smtp_user = ds.Tables[0].Rows[0]["Smtp_user"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_pass"].ToString()))
                        oSettings.Smtp_pass = ds.Tables[0].Rows[0]["Smtp_pass"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_port"].ToString()))
                        oSettings.Smtp_port = ds.Tables[0].Rows[0]["Smtp_port"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Mmode"].ToString()))
                        oSettings.Mmode = int.Parse(ds.Tables[0].Rows[0]["Mmode"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_crypto"].ToString()))
                        oSettings.Smtp_crypto = ds.Tables[0].Rows[0]["Smtp_crypto"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Captcha"].ToString()))
                        oSettings.Captcha = int.Parse(ds.Tables[0].Rows[0]["Captcha"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Mailpath"].ToString()))
                        oSettings.Mailpath = ds.Tables[0].Rows[0]["Mailpath"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Currency_prefix"].ToString()))
                        oSettings.Currency_prefix = ds.Tables[0].Rows[0]["Currency_prefix"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_customer"].ToString()))
                        oSettings.Default_customer = int.Parse(ds.Tables[0].Rows[0]["Default_customer"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_tax_rate"].ToString()))
                        oSettings.Default_tax_rate = ds.Tables[0].Rows[0]["Default_tax_rate"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rows_per_page"].ToString()))
                        oSettings.Rows_per_page = int.Parse(ds.Tables[0].Rows[0]["Rows_per_page"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_rows"].ToString()))
                        oSettings.Total_rows = int.Parse(ds.Tables[0].Rows[0]["Total_rows"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Header"].ToString()))
                        oSettings.Header = ds.Tables[0].Rows[0]["Header"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Footer"].ToString()))
                        oSettings.Footer = ds.Tables[0].Rows[0]["Footer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Bsty"].ToString()))
                        oSettings.Bsty = int.Parse(ds.Tables[0].Rows[0]["Bsty"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Display_kb"].ToString()))
                        oSettings.Display_kb = int.Parse(ds.Tables[0].Rows[0]["Display_kb"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_category"].ToString()))
                        oSettings.Default_category = int.Parse(ds.Tables[0].Rows[0]["Default_category"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_discount"].ToString()))
                        oSettings.Default_discount = ds.Tables[0].Rows[0]["Default_discount"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_addition"].ToString()))
                        oSettings.Item_addition = int.Parse(ds.Tables[0].Rows[0]["Item_addition"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Barcode_symbology"].ToString()))
                        oSettings.Barcode_symbology = ds.Tables[0].Rows[0]["Barcode_symbology"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pro_limit"].ToString()))
                        oSettings.Pro_limit = int.Parse(ds.Tables[0].Rows[0]["Pro_limit"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Decimals"].ToString()))
                        oSettings.Decimals = int.Parse(ds.Tables[0].Rows[0]["Decimals"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Thousands_sep"].ToString()))
                        oSettings.Thousands_sep = ds.Tables[0].Rows[0]["Thousands_sep"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Decimals_sep"].ToString()))
                        oSettings.Decimals_sep = ds.Tables[0].Rows[0]["Decimals_sep"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Focus_add_item"].ToString()))
                        oSettings.Focus_add_item = ds.Tables[0].Rows[0]["Focus_add_item"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Add_customer"].ToString()))
                        oSettings.Add_customer = ds.Tables[0].Rows[0]["Add_customer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Toggle_category_slider"].ToString()))
                        oSettings.Toggle_category_slider = ds.Tables[0].Rows[0]["Toggle_category_slider"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Cancel_sale"].ToString()))
                        oSettings.Cancel_sale = ds.Tables[0].Rows[0]["Cancel_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Suspend_sale"].ToString()))
                        oSettings.Suspend_sale = ds.Tables[0].Rows[0]["Suspend_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_order"].ToString()))
                        oSettings.Print_order = ds.Tables[0].Rows[0]["Print_order"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_bill"].ToString()))
                        oSettings.Print_bill = ds.Tables[0].Rows[0]["Print_bill"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Finalize_sale"].ToString()))
                        oSettings.Finalize_sale = ds.Tables[0].Rows[0]["Finalize_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Today_sale"].ToString()))
                        oSettings.Today_sale = ds.Tables[0].Rows[0]["Today_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Open_hold_bills"].ToString()))
                        oSettings.Open_hold_bills = ds.Tables[0].Rows[0]["Open_hold_bills"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Close_register"].ToString()))
                        oSettings.Close_register = ds.Tables[0].Rows[0]["Close_register"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Java_applet"].ToString()))
                        oSettings.Java_applet = int.Parse(ds.Tables[0].Rows[0]["Java_applet"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Receipt_printer"].ToString()))
                        oSettings.Receipt_printer = ds.Tables[0].Rows[0]["Receipt_printer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pos_printers"].ToString()))
                        oSettings.Pos_printers = ds.Tables[0].Rows[0]["Pos_printers"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Cash_drawer_codes"].ToString()))
                        oSettings.Cash_drawer_codes = ds.Tables[0].Rows[0]["Cash_drawer_codes"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Char_per_line"].ToString()))
                        oSettings.Char_per_line = int.Parse(ds.Tables[0].Rows[0]["Char_per_line"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rounding"].ToString()))
                        oSettings.Rounding = int.Parse(ds.Tables[0].Rows[0]["Rounding"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pin_code"].ToString()))
                        oSettings.Pin_code = ds.Tables[0].Rows[0]["Pin_code"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe"].ToString()))
                        oSettings.Stripe = int.Parse(ds.Tables[0].Rows[0]["Stripe"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe_secret_key"].ToString()))
                        oSettings.Stripe_secret_key = ds.Tables[0].Rows[0]["Stripe_secret_key"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe_publishable_key"].ToString()))
                        oSettings.Stripe_publishable_key = ds.Tables[0].Rows[0]["Stripe_publishable_key"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Purchase_code"].ToString()))
                        oSettings.Purchase_code = ds.Tables[0].Rows[0]["Purchase_code"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Envato_username"].ToString()))
                        oSettings.Envato_username = ds.Tables[0].Rows[0]["Envato_username"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Theme_style"].ToString()))
                        oSettings.Theme_style = ds.Tables[0].Rows[0]["Theme_style"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["After_sale_page"].ToString()))
                        oSettings.After_sale_page = int.Parse(ds.Tables[0].Rows[0]["After_sale_page"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Overselling"].ToString()))
                        oSettings.Overselling = int.Parse(ds.Tables[0].Rows[0]["Overselling"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Multi_store"].ToString()))
                        oSettings.Multi_store = ds.Tables[0].Rows[0]["Multi_store"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Qty_decimals"].ToString()))
                        oSettings.Qty_decimals = int.Parse(ds.Tables[0].Rows[0]["Qty_decimals"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Symbol"].ToString()))
                        oSettings.Symbol = ds.Tables[0].Rows[0]["Symbol"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Sac"].ToString()))
                        oSettings.Sac = int.Parse(ds.Tables[0].Rows[0]["Sac"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Display_symbol"].ToString()))
                        oSettings.Display_symbol = int.Parse(ds.Tables[0].Rows[0]["Display_symbol"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Remote_printing"].ToString()))
                        oSettings.Remote_printing = int.Parse(ds.Tables[0].Rows[0]["Remote_printing"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Printer"].ToString()))
                        oSettings.Printer = int.Parse(ds.Tables[0].Rows[0]["Printer"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_printers"].ToString()))
                        oSettings.Order_printers = ds.Tables[0].Rows[0]["Order_printers"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Auto_print"].ToString()))
                        oSettings.Auto_print = int.Parse(ds.Tables[0].Rows[0]["Auto_print"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Local_printers"].ToString()))
                        oSettings.Local_printers = int.Parse(ds.Tables[0].Rows[0]["Local_printers"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rtl"].ToString()))
                        oSettings.Rtl = int.Parse(ds.Tables[0].Rows[0]["Rtl"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_img"].ToString()))
                        oSettings.Print_img = int.Parse(ds.Tables[0].Rows[0]["Print_img"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Ws_barcode_type"].ToString()))
                        oSettings.Ws_barcode_type = ds.Tables[0].Rows[0]["Ws_barcode_type"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Ws_barcode_chars"].ToString()))
                        oSettings.Ws_barcode_chars = int.Parse(ds.Tables[0].Rows[0]["Ws_barcode_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Flag_chars"].ToString()))
                        oSettings.Flag_chars = int.Parse(ds.Tables[0].Rows[0]["Flag_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_code_start"].ToString()))
                        oSettings.Item_code_start = int.Parse(ds.Tables[0].Rows[0]["Item_code_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_code_chars"].ToString()))
                        oSettings.Item_code_chars = int.Parse(ds.Tables[0].Rows[0]["Item_code_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_start"].ToString()))
                        oSettings.Price_start = int.Parse(ds.Tables[0].Rows[0]["Price_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_chars"].ToString()))
                        oSettings.Price_chars = int.Parse(ds.Tables[0].Rows[0]["Price_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_divide_by"].ToString()))
                        oSettings.Price_divide_by = int.Parse(ds.Tables[0].Rows[0]["Price_divide_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Weight_start"].ToString()))
                        oSettings.Weight_start = int.Parse(ds.Tables[0].Rows[0]["Weight_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Weight_divide_by"].ToString()))
                        oSettings.Weight_divide_by = int.Parse(ds.Tables[0].Rows[0]["Weight_divide_by"].ToString());
                }

            }
            return oSettings;
        }

        public Settings M_Settings_InsertOrUpdate(Settings PoSettings)
        {
            DataSet ds = new DataSet();
            Settings oSettings = new Settings();
            SettingsDAL oSettingsDAL = new SettingsDAL();

            ds = oSettingsDAL.M_Settings_InsertOrUpdate(PoSettings.BranchId, PoSettings.Logo, PoSettings.Site_name, PoSettings.Tel, PoSettings.Dateformat, PoSettings.Timeformat, PoSettings.Default_email,
                PoSettings.Language, PoSettings.Version, PoSettings.Theme, PoSettings.Timezone, PoSettings.Protocol, PoSettings.Smtp_host, PoSettings.Smtp_user, PoSettings.Smtp_pass,
                PoSettings.Smtp_port, PoSettings.Smtp_crypto, PoSettings.Mmode, PoSettings.Captcha, PoSettings.Mailpath, PoSettings.Currency_prefix, PoSettings.Default_customer, PoSettings.Default_tax_rate,
                PoSettings.Rows_per_page, PoSettings.Total_rows, PoSettings.Header, PoSettings.Footer, PoSettings.Bsty, PoSettings.Display_kb, PoSettings.Default_category, PoSettings.Default_discount,
                PoSettings.Item_addition, PoSettings.Barcode_symbology, PoSettings.Pro_limit, PoSettings.Decimals, PoSettings.Thousands_sep, PoSettings.Decimals_sep, PoSettings.Focus_add_item,
                PoSettings.Add_customer, PoSettings.Toggle_category_slider, PoSettings.Cancel_sale, PoSettings.Suspend_sale, PoSettings.Print_order, PoSettings.Print_bill, PoSettings.Finalize_sale,
                PoSettings.Today_sale, PoSettings.Open_hold_bills, PoSettings.Close_register, PoSettings.Java_applet, PoSettings.Receipt_printer, PoSettings.Pos_printers, PoSettings.Cash_drawer_codes,
                PoSettings.Char_per_line, PoSettings.Rounding, PoSettings.Pin_code, PoSettings.Stripe, PoSettings.Stripe_secret_key, PoSettings.Stripe_publishable_key, PoSettings.Purchase_code,
                PoSettings.Envato_username, PoSettings.Theme_style, PoSettings.After_sale_page, PoSettings.Overselling, PoSettings.Multi_store, PoSettings.Qty_decimals, PoSettings.Symbol,
                PoSettings.Sac, PoSettings.Display_symbol, PoSettings.Remote_printing, PoSettings.Printer, PoSettings.Order_printers, PoSettings.Auto_print, PoSettings.Local_printers, PoSettings.Rtl,
                PoSettings.Print_img, PoSettings.Ws_barcode_type, PoSettings.Ws_barcode_chars, PoSettings.Flag_chars, PoSettings.Item_code_start, PoSettings.Item_code_chars, PoSettings.Price_start,
                PoSettings.Price_chars, PoSettings.Price_divide_by, PoSettings.Weight_start, PoSettings.Weight_chars, PoSettings.Weight_divide_by);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["BranchId"].ToString()))
                        oSettings.BranchId = int.Parse(ds.Tables[0].Rows[0]["BranchId"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Setting_id"].ToString()))
                        oSettings.Setting_id = int.Parse(ds.Tables[0].Rows[0]["Setting_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Dateformat"].ToString()))
                        oSettings.Dateformat = ds.Tables[0].Rows[0]["Dateformat"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Logo"].ToString()))
                        oSettings.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Timeformat"].ToString()))
                        oSettings.Timeformat = ds.Tables[0].Rows[0]["Timeformat"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Site_name"].ToString()))
                        oSettings.Site_name = ds.Tables[0].Rows[0]["Site_name"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Tel"].ToString()))
                        oSettings.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_email"].ToString()))
                        oSettings.Default_email = ds.Tables[0].Rows[0]["Default_email"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Language"].ToString()))
                        oSettings.Language = ds.Tables[0].Rows[0]["Language"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Version"].ToString()))
                        oSettings.Version = ds.Tables[0].Rows[0]["Version"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Theme"].ToString()))
                        oSettings.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Timezone"].ToString()))
                        oSettings.Timezone = ds.Tables[0].Rows[0]["Timezone"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Protocol"].ToString()))
                        oSettings.Protocol = ds.Tables[0].Rows[0]["Protocol"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_host"].ToString()))
                        oSettings.Smtp_host = ds.Tables[0].Rows[0]["Smtp_host"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_user"].ToString()))
                        oSettings.Smtp_user = ds.Tables[0].Rows[0]["Smtp_user"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_pass"].ToString()))
                        oSettings.Smtp_pass = ds.Tables[0].Rows[0]["Smtp_pass"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_port"].ToString()))
                        oSettings.Smtp_port = ds.Tables[0].Rows[0]["Smtp_port"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Mmode"].ToString()))
                        oSettings.Mmode = int.Parse(ds.Tables[0].Rows[0]["Mmode"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Smtp_crypto"].ToString()))
                        oSettings.Smtp_crypto = ds.Tables[0].Rows[0]["Smtp_crypto"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Captcha"].ToString()))
                        oSettings.Captcha = int.Parse(ds.Tables[0].Rows[0]["Captcha"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Mailpath"].ToString()))
                        oSettings.Mailpath = ds.Tables[0].Rows[0]["Mailpath"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Currency_prefix"].ToString()))
                        oSettings.Currency_prefix = ds.Tables[0].Rows[0]["Currency_prefix"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_customer"].ToString()))
                        oSettings.Default_customer = int.Parse(ds.Tables[0].Rows[0]["Default_customer"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_tax_rate"].ToString()))
                        oSettings.Default_tax_rate = ds.Tables[0].Rows[0]["Default_tax_rate"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rows_per_page"].ToString()))
                        oSettings.Rows_per_page = int.Parse(ds.Tables[0].Rows[0]["Rows_per_page"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_rows"].ToString()))
                        oSettings.Total_rows = int.Parse(ds.Tables[0].Rows[0]["Total_rows"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Header"].ToString()))
                        oSettings.Header = ds.Tables[0].Rows[0]["Header"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Footer"].ToString()))
                        oSettings.Footer = ds.Tables[0].Rows[0]["Footer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Bsty"].ToString()))
                        oSettings.Bsty = int.Parse(ds.Tables[0].Rows[0]["Bsty"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Display_kb"].ToString()))
                        oSettings.Display_kb = int.Parse(ds.Tables[0].Rows[0]["Display_kb"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_category"].ToString()))
                        oSettings.Default_category = int.Parse(ds.Tables[0].Rows[0]["Default_category"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Default_discount"].ToString()))
                        oSettings.Default_discount = ds.Tables[0].Rows[0]["Default_discount"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_addition"].ToString()))
                        oSettings.Item_addition = int.Parse(ds.Tables[0].Rows[0]["Item_addition"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Barcode_symbology"].ToString()))
                        oSettings.Barcode_symbology = ds.Tables[0].Rows[0]["Barcode_symbology"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pro_limit"].ToString()))
                        oSettings.Pro_limit = int.Parse(ds.Tables[0].Rows[0]["Pro_limit"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Decimals"].ToString()))
                        oSettings.Decimals = int.Parse(ds.Tables[0].Rows[0]["Decimals"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Thousands_sep"].ToString()))
                        oSettings.Thousands_sep = ds.Tables[0].Rows[0]["Thousands_sep"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Decimals_sep"].ToString()))
                        oSettings.Decimals_sep = ds.Tables[0].Rows[0]["Decimals_sep"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Focus_add_item"].ToString()))
                        oSettings.Focus_add_item = ds.Tables[0].Rows[0]["Focus_add_item"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Add_customer"].ToString()))
                        oSettings.Add_customer = ds.Tables[0].Rows[0]["Add_customer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Toggle_category_slider"].ToString()))
                        oSettings.Toggle_category_slider = ds.Tables[0].Rows[0]["Toggle_category_slider"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Cancel_sale"].ToString()))
                        oSettings.Cancel_sale = ds.Tables[0].Rows[0]["Cancel_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Suspend_sale"].ToString()))
                        oSettings.Suspend_sale = ds.Tables[0].Rows[0]["Suspend_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_order"].ToString()))
                        oSettings.Print_order = ds.Tables[0].Rows[0]["Print_order"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_bill"].ToString()))
                        oSettings.Print_bill = ds.Tables[0].Rows[0]["Print_bill"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Finalize_sale"].ToString()))
                        oSettings.Finalize_sale = ds.Tables[0].Rows[0]["Finalize_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Today_sale"].ToString()))
                        oSettings.Today_sale = ds.Tables[0].Rows[0]["Today_sale"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Open_hold_bills"].ToString()))
                        oSettings.Open_hold_bills = ds.Tables[0].Rows[0]["Open_hold_bills"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Close_register"].ToString()))
                        oSettings.Close_register = ds.Tables[0].Rows[0]["Close_register"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Java_applet"].ToString()))
                        oSettings.Java_applet = int.Parse(ds.Tables[0].Rows[0]["Java_applet"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Receipt_printer"].ToString()))
                        oSettings.Receipt_printer = ds.Tables[0].Rows[0]["Receipt_printer"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pos_printers"].ToString()))
                        oSettings.Pos_printers = ds.Tables[0].Rows[0]["Pos_printers"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Cash_drawer_codes"].ToString()))
                        oSettings.Cash_drawer_codes = ds.Tables[0].Rows[0]["Cash_drawer_codes"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Char_per_line"].ToString()))
                        oSettings.Char_per_line = int.Parse(ds.Tables[0].Rows[0]["Char_per_line"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rounding"].ToString()))
                        oSettings.Rounding = int.Parse(ds.Tables[0].Rows[0]["Rounding"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Pin_code"].ToString()))
                        oSettings.Pin_code = ds.Tables[0].Rows[0]["Pin_code"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe"].ToString()))
                        oSettings.Stripe = int.Parse(ds.Tables[0].Rows[0]["Stripe"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe_secret_key"].ToString()))
                        oSettings.Stripe_secret_key = ds.Tables[0].Rows[0]["Stripe_secret_key"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Stripe_publishable_key"].ToString()))
                        oSettings.Stripe_publishable_key = ds.Tables[0].Rows[0]["Stripe_publishable_key"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Purchase_code"].ToString()))
                        oSettings.Purchase_code = ds.Tables[0].Rows[0]["Purchase_code"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Envato_username"].ToString()))
                        oSettings.Envato_username = ds.Tables[0].Rows[0]["Envato_username"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Theme_style"].ToString()))
                        oSettings.Theme_style = ds.Tables[0].Rows[0]["Theme_style"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["After_sale_page"].ToString()))
                        oSettings.After_sale_page = int.Parse(ds.Tables[0].Rows[0]["After_sale_page"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Overselling"].ToString()))
                        oSettings.Overselling = int.Parse(ds.Tables[0].Rows[0]["Overselling"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Multi_store"].ToString()))
                        oSettings.Multi_store = ds.Tables[0].Rows[0]["Multi_store"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Qty_decimals"].ToString()))
                        oSettings.Qty_decimals = int.Parse(ds.Tables[0].Rows[0]["Qty_decimals"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Symbol"].ToString()))
                        oSettings.Symbol = ds.Tables[0].Rows[0]["Symbol"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Sac"].ToString()))
                        oSettings.Sac = int.Parse(ds.Tables[0].Rows[0]["Sac"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Display_symbol"].ToString()))
                        oSettings.Display_symbol = int.Parse(ds.Tables[0].Rows[0]["Display_symbol"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Remote_printing"].ToString()))
                        oSettings.Remote_printing = int.Parse(ds.Tables[0].Rows[0]["Remote_printing"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Printer"].ToString()))
                        oSettings.Printer = int.Parse(ds.Tables[0].Rows[0]["Printer"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_printers"].ToString()))
                        oSettings.Order_printers = ds.Tables[0].Rows[0]["Order_printers"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Auto_print"].ToString()))
                        oSettings.Auto_print = int.Parse(ds.Tables[0].Rows[0]["Auto_print"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Local_printers"].ToString()))
                        oSettings.Local_printers = int.Parse(ds.Tables[0].Rows[0]["Local_printers"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rtl"].ToString()))
                        oSettings.Rtl = int.Parse(ds.Tables[0].Rows[0]["Rtl"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Print_img"].ToString()))
                        oSettings.Print_img = int.Parse(ds.Tables[0].Rows[0]["Print_img"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Ws_barcode_type"].ToString()))
                        oSettings.Ws_barcode_type = ds.Tables[0].Rows[0]["Ws_barcode_type"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Ws_barcode_chars"].ToString()))
                        oSettings.Ws_barcode_chars = int.Parse(ds.Tables[0].Rows[0]["Ws_barcode_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Flag_chars"].ToString()))
                        oSettings.Flag_chars = int.Parse(ds.Tables[0].Rows[0]["Flag_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_code_start"].ToString()))
                        oSettings.Item_code_start = int.Parse(ds.Tables[0].Rows[0]["Item_code_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Item_code_chars"].ToString()))
                        oSettings.Item_code_chars = int.Parse(ds.Tables[0].Rows[0]["Item_code_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_start"].ToString()))
                        oSettings.Price_start = int.Parse(ds.Tables[0].Rows[0]["Price_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_chars"].ToString()))
                        oSettings.Price_chars = int.Parse(ds.Tables[0].Rows[0]["Price_chars"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Price_divide_by"].ToString()))
                        oSettings.Price_divide_by = int.Parse(ds.Tables[0].Rows[0]["Price_divide_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Weight_start"].ToString()))
                        oSettings.Weight_start = int.Parse(ds.Tables[0].Rows[0]["Weight_start"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Weight_divide_by"].ToString()))
                        oSettings.Weight_divide_by = int.Parse(ds.Tables[0].Rows[0]["Weight_divide_by"].ToString());
                }

            }
            return oSettings;
        }
    }
}
