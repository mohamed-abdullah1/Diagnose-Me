export const specialties = [
    {
        key: 1,
        value: "Hepatology",
        src: require("../../assets/specialities/Hepatology1.png"),
    },
    {
        key: 5,
        value: "Dentistry",
        src: require("../../assets/specialities/Dentistry1.png"),
    },
    {
        key: 4,
        value: "Cardiology",
        src: require("../../assets/specialities/Cardiology1.png"),
    },
    {
        key: 2,
        value: "dermatologist",
        src: require("../../assets/specialities/dermatologist1.png"),
    },
    {
        key: 3,
        value: "Gastroenterology",
        src: require("../../assets/specialities/Gastroenterology1.png"),
    },
    {
        key: 6,
        value: "Pulmonology",
        src: require("../../assets/specialities/Pulmonology1.png"),
    },
    {
        key: 7,
        value: "Optometry",
        src: require("../../assets/specialities/Optometry1.png"),
    },
    {
        key: 8,
        value: "Neurologists",
        src: require("../../assets/specialities/Neurologists1.png"),
    },
];

export const doctors = [
    {
        id: 1,
        name: "Hana Elmansy",
        specialty: "Dentistry",
        yearsOfExperience: 3,
        numberOfPatients: 150,
        rate: 4.5,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        pricePerHour: 90,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 2,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        yearsOfExperience: 1,
        numberOfPatients: 100,
        rate: 4,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        pricePerHour: 59,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 3,
        name: "Soha ElSawy",
        specialty: "Hepatology",
        yearsOfExperience: 1,
        numberOfPatients: 100,
        rate: 4,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_female_2.png"),
        pricePerHour: 85,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
];
export const patients = [
    {
        id: 1,
        patientName: "Mohamed Elsayed",
    },
];
export const doctorAvailableMeetings = [
    {
        meetingId: 1,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 13,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 2,
        available: false,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 14,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 3,
        available: false,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 15,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 4,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 16,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 5,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 17,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 6,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 18,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 7,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 19,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 8,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 20,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 9,
        available: true,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 13,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 10,
        available: false,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 14,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 11,
        available: false,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 15,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
];

export const services = [
    {
        id: 1,
        title: "AI Services",
        src: require("../../assets/services/AI.png"),
    },
    {
        id: 2,
        title: "Medicine",
        src: require("../../assets/services/medicine.png"),
    },
    {
        id: 3,
        title: "Blood Donation",
        src: require("../../assets/services/bloodDonation.png"),
    },
    {
        id: 4,
        title: "Exercises",
        src: require("../../assets/services/exercises.png"),
    },
];

export const trendQuestions = [
    {
        id: 1,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Khaled Mohamed",
        date: "10 min",
        ups: 15,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 2,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Mostfa Hany",
        date: "10 min",
        ups: 10,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 3,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Messi Elgen",
        date: "10 min",
        ups: 9,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 4,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Samy Hamza",
        date: "10 min",
        ups: 15,
        downs: 1,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
];
export const blogs = [
    {
        id: 1,
        doctorName: "Samy Mohamed",
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
    {
        id: 2,
        doctorName: "Soha Hossam",
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 10,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
    {
        id: 3,
        doctorName: "Sandy Elhelo",
        dcotorImg: require("../../assets/characters/doctor_female_2.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
];

export const messages = [
    {
        id: 1,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine  🌍", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 2,
        patientId: 1,
        doctorId: 2,
        message: { content: "Tell Me Are You Fine😊", owner: "doctor" },
        time: {
            timeValue: "6:00",
            amOrPm: "pm",
        },
    },
    {
        id: 3,
        patientId: 1,
        doctorId: 3,
        message: { content: "Can You Send Me More Info🍀", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 4,
        patientId: 1,
        doctorId: 1,
        message: { content: "Can We Make Call🚨", owner: "patient" },
        time: {
            timeValue: "9:00",
            amOrPm: "am",
        },
    },
    {
        id: 5,
        patientId: 1,
        doctorId: 3,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 6,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 7,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 8,
        patientId: 1,
        doctorId: 3,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
];

export const msgs = [
    {
        id: 1,
        patientId: 1,
        doctorId: 1,
        messages: [
            {
                id: 1,
                content: "How Are You ?!",
                owner: "doctor",
                time: {
                    hour: 4,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
            {
                id: 2,
                content: "I am Fine 😃",
                owner: "patient",
                time: {
                    hour: 5,
                    minute: 1,
                    second: 0,
                    amOrPm: "pm",
                },
            },
            {
                id: 3,
                content: "When will be our next meeting ?",
                owner: "patient",
                time: {
                    hour: 5,
                    minute: 2,
                    second: 0,
                    amOrPm: "pm",
                },
            },
            {
                id: 4,
                content:
                    "I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 ",
                owner: "doctor",
                time: {
                    hour: 5,
                    minute: 3,
                    second: 0,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: false,
        patientActive: true,
        //patientImg,
        //DoctorImg,
        //DoctorName,
        //Doctor
    },
    {
        id: 2,
        patientId: 1,
        doctorId: 2,
        messages: [
            {
                id: 1,
                content: "Are You Fine 💁 ?",
                owner: "doctor",
                time: {
                    hour: 9,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
            {
                id: 2,
                content: "Yep 👀",
                owner: "patient",
                time: {
                    hour: 9,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: true,
        patientActive: true,
    },
    {
        id: 3,
        patientId: 1,
        doctorId: 3,
        messages: [
            {
                id: 1,
                content: "Doctor Are You Here!! 🌎",
                owner: "patient",
                time: {
                    hour: 8,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: false,
        patientActive: true,
    },
];
