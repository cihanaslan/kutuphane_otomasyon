PGDMP     6    6                  {            Kutuphane_son2    14.3    15.0     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    41150    Kutuphane_son2    DATABASE     �   CREATE DATABASE "Kutuphane_son2" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Turkish_Turkey.1254';
     DROP DATABASE "Kutuphane_son2";
                postgres    false                        2615    2200    public    SCHEMA     2   -- *not* creating schema, since initdb creates it
 2   -- *not* dropping schema, since initdb creates it
                postgres    false                        0    0    SCHEMA public    ACL     Q   REVOKE USAGE ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO PUBLIC;
                   postgres    false    5            �            1259    41303    emanetkitaplar    TABLE     �  CREATE TABLE public.emanetkitaplar (
    uyetc bigint NOT NULL,
    uyead character varying,
    uyesoyad character varying,
    uyedogumt date,
    uyetel character varying,
    emkitapbar bigint NOT NULL,
    emkitapadi character varying,
    emkitapyazar character varying,
    emkitapyayinevi character varying,
    emkitapsf character varying,
    emkitapsayi integer,
    emkitapteslimt date,
    emkitapiadet date
);
 "   DROP TABLE public.emanetkitaplar;
       public         heap    postgres    false    5            �            1259    41223    kitap    TABLE     *  CREATE TABLE public.kitap (
    kitapbarkod bigint NOT NULL,
    kitapad character varying,
    yazar character varying,
    yayinevi character varying,
    sayfasayi character varying,
    tur character varying,
    stoksayi integer,
    rafno character varying,
    aciklama character varying
);
    DROP TABLE public.kitap;
       public         heap    postgres    false    5            �            1259    41216    sepet    TABLE       CREATE TABLE public.sepet (
    emkitapbar bigint NOT NULL,
    emkitapadi character varying,
    emkitapyazar character varying,
    emkitapyayinevi character varying,
    emkitapsf character varying,
    emkitapsayi integer,
    emkitapteslimt date,
    emkitapiadet date
);
    DROP TABLE public.sepet;
       public         heap    postgres    false    5            �            1259    41209    uye    TABLE       CREATE TABLE public.uye (
    tc bigint NOT NULL,
    ad character varying,
    soyad character varying,
    dogumt date,
    cinsiyet character varying,
    telefon character varying NOT NULL,
    adres character varying,
    email character varying,
    okunankitap integer
);
    DROP TABLE public.uye;
       public         heap    postgres    false    5            �          0    41303    emanetkitaplar 
   TABLE DATA           �   COPY public.emanetkitaplar (uyetc, uyead, uyesoyad, uyedogumt, uyetel, emkitapbar, emkitapadi, emkitapyazar, emkitapyayinevi, emkitapsf, emkitapsayi, emkitapteslimt, emkitapiadet) FROM stdin;
    public          postgres    false    212   "       �          0    41223    kitap 
   TABLE DATA           q   COPY public.kitap (kitapbarkod, kitapad, yazar, yayinevi, sayfasayi, tur, stoksayi, rafno, aciklama) FROM stdin;
    public          postgres    false    211   ?       �          0    41216    sepet 
   TABLE DATA           �   COPY public.sepet (emkitapbar, emkitapadi, emkitapyazar, emkitapyayinevi, emkitapsf, emkitapsayi, emkitapteslimt, emkitapiadet) FROM stdin;
    public          postgres    false    210   �       �          0    41209    uye 
   TABLE DATA           b   COPY public.uye (tc, ad, soyad, dogumt, cinsiyet, telefon, adres, email, okunankitap) FROM stdin;
    public          postgres    false    209   �       j           2606    41229    kitap kitap_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.kitap
    ADD CONSTRAINT kitap_pkey PRIMARY KEY (kitapbarkod);
 :   ALTER TABLE ONLY public.kitap DROP CONSTRAINT kitap_pkey;
       public            postgres    false    211            h           2606    41215    uye uye_pkey 
   CONSTRAINT     J   ALTER TABLE ONLY public.uye
    ADD CONSTRAINT uye_pkey PRIMARY KEY (tc);
 6   ALTER TABLE ONLY public.uye DROP CONSTRAINT uye_pkey;
       public            postgres    false    209            �      x������ � �      �   �  x�UQ=o�0��_q���,����A;h���-ƹ�t*(9��C�z�Z-��Q�_92I�l����=��a���zsI����e���E���������(�i0�i�4��
�ћ�KS����� ���z�D��i`=(H7>
���3�g�������PZ�w:ȉ�A�)�.��b�0X�uq`�՘�� yzQr��1l�?_�1�Ȗ���W����e����:��G?���`oUK_@�*S��V,39=֞~� ùGI�T���v��,/�7����E�Y�X�9�iϫ?j��3��<q����M��X���V��t�ԧ�b�q���o�M�P4�Q��I�4XE�����5��E����bq_��^��:ƽ����ʓ��{m��(a��{�j�6�+��f��b�      �      x������ � �      �   �   x�U�1�@E��Sppw�a��DKlЂ�f4D$�Ė3x9���߾��&���2�B64��۵�č��w����2ea�Uy�Be""+%�=WC�I�$=��ŷE��\���ր(5Z-��2���5/\-7��ʗ��ђ4�5˟�)��v._#|+ǿ�8B��b;�     