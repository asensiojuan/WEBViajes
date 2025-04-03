// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Sidebar functionality
document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.getElementById('sidebar');
    const content = document.getElementById('content');
    const sidebarToggle = document.getElementById('sidebarToggle');
    const isMobile = window.innerWidth < 768;

    // Check if we should store sidebar state
    const storeSidebarState = function (isOpen) {
        localStorage.setItem('sidebarOpen', isOpen ? 'true' : 'false');
    };

    // Get saved sidebar state
    const getSidebarState = function () {
        return localStorage.getItem('sidebarOpen') === 'true';
    };

    // Set initial state based on device and saved preference
    const initializeSidebar = function () {
        const savedState = getSidebarState();

        if (isMobile) {
            // On mobile, always start with sidebar closed
            sidebar.classList.remove('show');
            content.classList.remove('full-width');
        } else {
            // On desktop, respect user preference if exists
            if (savedState !== null) {
                if (savedState === false) {
                    // If user closed it before
                    sidebar.classList.remove('show');
                    content.classList.add('full-width');
                }
            }
        }
    };

    // Toggle sidebar function
    const toggleSidebar = function () {
        if (isMobile) {
            sidebar.classList.toggle('show');
        } else {
            content.classList.toggle('full-width');
            // Store preference for desktop only
            storeSidebarState(!content.classList.contains('full-width'));
        }
    };

    // Add click event
    if (sidebarToggle) {
        sidebarToggle.addEventListener('click', function (e) {
            e.preventDefault();
            toggleSidebar();
        });
    }

    // Initialize sidebar on page load
    initializeSidebar();

    // Handle window resize
    window.addEventListener('resize', function () {
        const newIsMobile = window.innerWidth < 768;

        // Only do something if we cross the breakpoint
        if (isMobile !== newIsMobile) {
            location.reload(); // Simple approach: reload to reinitialize layout
        }
    });

    // Add active class to the current page if needed
    const setActiveNavLink = function () {
        // Get current path
        const path = window.location.pathname;

        // Find all nav links
        const navLinks = document.querySelectorAll('.sidebar .nav-link');

        // Check each link
        navLinks.forEach(function (link) {
            if (link.getAttribute('href') === path) {
                link.classList.add('active');
            }
        });
    };

    // Call the function to set active link
    setActiveNavLink();
});
